namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveGameStyleType(DomainEditModel GameStyleType) : ICommand
{
    public class Handler : CommandHandler<SaveGameStyleType>
    {
        private readonly IDomainRepository<Entity.GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task Handle(SaveGameStyleType request)
        {
            Entity.GameStyleType gameStyleType;

            if (request.GameStyleType.IsNew)
            {
                gameStyleType = new Entity.GameStyleType(request.GameStyleType.Name, 
                                                         request.GameStyleType.Abbreviation);

                await _gameStyleTypeRepository.Add(gameStyleType);

                return;
            }

            gameStyleType = await _gameStyleTypeRepository.Get(request.GameStyleType.Id);

            if (request.GameStyleType.IsDeleted)
            {
                await _gameStyleTypeRepository.Delete(gameStyleType);

                return;
            }

            gameStyleType.Set(request.GameStyleType.Name, 
                              request.GameStyleType.Abbreviation);

            await _gameStyleTypeRepository.Update(gameStyleType);
        }
    }
}
