using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record SavePrivacyType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePrivacyType>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task Handle(SavePrivacyType request)
        {
            PrivacyType privacyType;

            if (request.ViewModel.IsNew)
            {
                privacyType = new PrivacyType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _privacyTypeRepository.Add(privacyType);

                return;
            }

            privacyType = await _privacyTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _privacyTypeRepository.Delete(privacyType);

                return;
            }

            privacyType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _privacyTypeRepository.Update(privacyType);
        }
    }
}
