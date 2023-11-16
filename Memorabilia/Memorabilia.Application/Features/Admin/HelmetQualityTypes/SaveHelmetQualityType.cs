namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveHelmetQualityType(DomainEditModel HelmetQualityType) : ICommand
{
    public class Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository) 
        : CommandHandler<SaveHelmetQualityType>
    {
        protected override async Task Handle(SaveHelmetQualityType request)
        {
            Entity.HelmetQualityType helmetQualityType;

            if (request.HelmetQualityType.IsNew)
            {
                helmetQualityType = new Entity.HelmetQualityType(request.HelmetQualityType.Name, 
                                                                 request.HelmetQualityType.Abbreviation);

                await helmetQualityTypeRepository.Add(helmetQualityType);

                return;
            }

            helmetQualityType = await helmetQualityTypeRepository.Get(request.HelmetQualityType.Id);

            if (request.HelmetQualityType.IsDeleted)
            {
                await helmetQualityTypeRepository.Delete(helmetQualityType);

                return;
            }

            helmetQualityType.Set(request.HelmetQualityType.Name, 
                                  request.HelmetQualityType.Abbreviation);

            await helmetQualityTypeRepository.Update(helmetQualityType);
        }
    }
}
