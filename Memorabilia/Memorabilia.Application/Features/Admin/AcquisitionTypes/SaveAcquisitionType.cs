namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveAcquisitionType(DomainEditModel AcquisitionType) : ICommand
{
    public class Handler : CommandHandler<SaveAcquisitionType>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task Handle(SaveAcquisitionType request)
        {
            Entity.AcquisitionType acquisitionType;

            if (request.AcquisitionType.IsNew)
            {
                acquisitionType = new Entity.AcquisitionType(request.AcquisitionType.Name, 
                                                             request.AcquisitionType.Abbreviation);

                await _acquisitionTypeRepository.Add(acquisitionType);

                return;
            }

            acquisitionType = await _acquisitionTypeRepository.Get(request.AcquisitionType.Id);

            if (request.AcquisitionType.IsDeleted)
            {
                await _acquisitionTypeRepository.Delete(acquisitionType);

                return;
            }

            acquisitionType.Set(request.AcquisitionType.Name, 
                                request.AcquisitionType.Abbreviation);

            await _acquisitionTypeRepository.Update(acquisitionType);
        }
    }
}
