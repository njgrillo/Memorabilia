namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveJerseyQualityType(DomainEditModel JerseyQualityType) : ICommand
{
    public class Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository) 
        : CommandHandler<SaveJerseyQualityType>
    {
        protected override async Task Handle(SaveJerseyQualityType request)
        {
            Entity.JerseyQualityType jerseyQualityType;

            if (request.JerseyQualityType.IsNew)
            {
                jerseyQualityType = new Entity.JerseyQualityType(request.JerseyQualityType.Name, 
                                                                 request.JerseyQualityType.Abbreviation);

                await jerseyQualityTypeRepository.Add(jerseyQualityType);

                return;
            }

            jerseyQualityType = await jerseyQualityTypeRepository.Get(request.JerseyQualityType.Id);

            if (request.JerseyQualityType.IsDeleted)
            {
                await jerseyQualityTypeRepository.Delete(jerseyQualityType);

                return;
            }

            jerseyQualityType.Set(request.JerseyQualityType.Name, 
                                  request.JerseyQualityType.Abbreviation);

            await jerseyQualityTypeRepository.Update(jerseyQualityType);
        }
    }
}
