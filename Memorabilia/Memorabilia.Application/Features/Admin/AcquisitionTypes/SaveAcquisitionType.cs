namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveAcquisitionType(DomainEditModel AcquisitionType) 
    : ICommand
{
    public class Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository) 
        : CommandHandler<SaveAcquisitionType>
    {
        protected override async Task Handle(SaveAcquisitionType request)
        {
            Entity.AcquisitionType acquisitionType;

            if (request.AcquisitionType.IsNew)
            {
                acquisitionType = new Entity.AcquisitionType(request.AcquisitionType.Name, 
                                                             request.AcquisitionType.Abbreviation);

                await acquisitionTypeRepository.Add(acquisitionType);

                return;
            }

            acquisitionType = await acquisitionTypeRepository.Get(request.AcquisitionType.Id);

            if (request.AcquisitionType.IsDeleted)
            {
                await acquisitionTypeRepository.Delete(acquisitionType);

                return;
            }

            acquisitionType.Set(request.AcquisitionType.Name, 
                                request.AcquisitionType.Abbreviation);

            await acquisitionTypeRepository.Update(acquisitionType);
        }
    }
}
