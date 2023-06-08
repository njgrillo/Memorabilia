namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record SaveAcquisitionType(DomainEditModel ViewModel) : ICommand
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

            if (request.ViewModel.IsNew)
            {
                acquisitionType = new Entity.AcquisitionType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _acquisitionTypeRepository.Add(acquisitionType);

                return;
            }

            acquisitionType = await _acquisitionTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _acquisitionTypeRepository.Delete(acquisitionType);

                return;
            }

            acquisitionType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _acquisitionTypeRepository.Update(acquisitionType);
        }
    }
}
