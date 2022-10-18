using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record SaveHelmetQualityType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetQualityType>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task Handle(SaveHelmetQualityType request)
        {
            HelmetQualityType helmetQualityType;

            if (request.ViewModel.IsNew)
            {
                helmetQualityType = new HelmetQualityType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _helmetQualityTypeRepository.Add(helmetQualityType);

                return;
            }

            helmetQualityType = await _helmetQualityTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _helmetQualityTypeRepository.Delete(helmetQualityType);

                return;
            }

            helmetQualityType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _helmetQualityTypeRepository.Update(helmetQualityType);
        }
    }
}
