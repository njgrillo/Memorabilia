namespace Memorabilia.Application.Features.Admin.LevelTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveLevelType(DomainEditModel LevelType) : ICommand
{
    public class Handler(IDomainRepository<Entity.LevelType> levelTypeRepository) 
        : CommandHandler<SaveLevelType>
    {
        protected override async Task Handle(SaveLevelType request)
        {
            Entity.LevelType levelType;

            if (request.LevelType.IsNew)
            {
                levelType = new Entity.LevelType(request.LevelType.Name, 
                                                 request.LevelType.Abbreviation);

                await levelTypeRepository.Add(levelType);

                return;
            }

            levelType = await levelTypeRepository.Get(request.LevelType.Id);

            if (request.LevelType.IsDeleted)
            {
                await levelTypeRepository.Delete(levelType);

                return;
            }

            levelType.Set(request.LevelType.Name, 
                          request.LevelType.Abbreviation);

            await levelTypeRepository.Update(levelType);
        }
    }
}
