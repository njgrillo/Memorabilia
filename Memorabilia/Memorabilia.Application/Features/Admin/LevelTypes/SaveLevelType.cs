namespace Memorabilia.Application.Features.Admin.LevelTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveLevelType(DomainEditModel LevelType) : ICommand
{
    public class Handler : CommandHandler<SaveLevelType>
    {
        private readonly IDomainRepository<Entity.LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<Entity.LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task Handle(SaveLevelType request)
        {
            Entity.LevelType levelType;

            if (request.LevelType.IsNew)
            {
                levelType = new Entity.LevelType(request.LevelType.Name, 
                                                 request.LevelType.Abbreviation);

                await _levelTypeRepository.Add(levelType);

                return;
            }

            levelType = await _levelTypeRepository.Get(request.LevelType.Id);

            if (request.LevelType.IsDeleted)
            {
                await _levelTypeRepository.Delete(levelType);

                return;
            }

            levelType.Set(request.LevelType.Name, 
                          request.LevelType.Abbreviation);

            await _levelTypeRepository.Update(levelType);
        }
    }
}
