namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveGameStyleType(DomainEditModel GameStyleType) : ICommand
{
    public class Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository) 
        : CommandHandler<SaveGameStyleType>
    {
        protected override async Task Handle(SaveGameStyleType request)
        {
            Entity.GameStyleType gameStyleType;

            if (request.GameStyleType.IsNew)
            {
                gameStyleType = new Entity.GameStyleType(request.GameStyleType.Name, 
                                                         request.GameStyleType.Abbreviation);

                await gameStyleTypeRepository.Add(gameStyleType);

                return;
            }

            gameStyleType = await gameStyleTypeRepository.Get(request.GameStyleType.Id);

            if (request.GameStyleType.IsDeleted)
            {
                await gameStyleTypeRepository.Delete(gameStyleType);

                return;
            }

            gameStyleType.Set(request.GameStyleType.Name, 
                              request.GameStyleType.Abbreviation);

            await gameStyleTypeRepository.Update(gameStyleType);
        }
    }
}
