using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record SaveJerseyQualityType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyQualityType>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task Handle(SaveJerseyQualityType request)
        {
            JerseyQualityType jerseyQualityType;

            if (request.ViewModel.IsNew)
            {
                jerseyQualityType = new JerseyQualityType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _jerseyQualityTypeRepository.Add(jerseyQualityType);

                return;
            }

            jerseyQualityType = await _jerseyQualityTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _jerseyQualityTypeRepository.Delete(jerseyQualityType);

                return;
            }

            jerseyQualityType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _jerseyQualityTypeRepository.Update(jerseyQualityType);
        }
    }
}
