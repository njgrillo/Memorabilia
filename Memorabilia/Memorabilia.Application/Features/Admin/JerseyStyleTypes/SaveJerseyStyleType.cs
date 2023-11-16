namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveJerseyStyleType(DomainEditModel JerseyStyleType) : ICommand
{
    public class Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository) 
        : CommandHandler<SaveJerseyStyleType>
    {
        protected override async Task Handle(SaveJerseyStyleType request)
        {
            Entity.JerseyStyleType jerseyStyleType;

            if (request.JerseyStyleType.IsNew)
            {
                jerseyStyleType = new Entity.JerseyStyleType(request.JerseyStyleType.Name, 
                                                             request.JerseyStyleType.Abbreviation);

                await jerseyStyleTypeRepository.Add(jerseyStyleType);

                return;
            }

            jerseyStyleType = await jerseyStyleTypeRepository.Get(request.JerseyStyleType.Id);

            if (request.JerseyStyleType.IsDeleted)
            {
                await jerseyStyleTypeRepository.Delete(jerseyStyleType);

                return;
            }

            jerseyStyleType.Set(request.JerseyStyleType.Name, 
                                request.JerseyStyleType.Abbreviation);

            await jerseyStyleTypeRepository.Update(jerseyStyleType);
        }
    }
}
