using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record SaveAcquisitionType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAcquisitionType>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task Handle(SaveAcquisitionType request)
        {
            AcquisitionType acquisitionType;

            if (request.ViewModel.IsNew)
            {
                acquisitionType = new AcquisitionType(request.ViewModel.Name, request.ViewModel.Abbreviation);

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
