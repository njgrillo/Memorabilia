namespace Memorabilia.Application.Features.Admin.JerseyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveJerseyType(DomainEditModel JerseyType) : ICommand
{
    public class Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository) 
        : CommandHandler<SaveJerseyType>
    {
        protected override async Task Handle(SaveJerseyType request)
        {
            Entity.JerseyType jerseyType;

            if (request.JerseyType.IsNew)
            {
                jerseyType = new Entity.JerseyType(request.JerseyType.Name, 
                                                   request.JerseyType.Abbreviation);

                await jerseyTypeRepository.Add(jerseyType);

                return;
            }

            jerseyType = await jerseyTypeRepository.Get(request.JerseyType.Id);

            if (request.JerseyType.IsDeleted)
            {
                await jerseyTypeRepository.Delete(jerseyType);

                return;
            }

            jerseyType.Set(request.JerseyType.Name, 
                           request.JerseyType.Abbreviation);

            await jerseyTypeRepository.Update(jerseyType);
        }
    }
}
