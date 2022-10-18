using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyTypes() : IQuery<PrivacyTypesViewModel>
{
    public class Handler : QueryHandler<GetPrivacyTypes, PrivacyTypesViewModel>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<PrivacyTypesViewModel> Handle(GetPrivacyTypes query)
        {
            return new PrivacyTypesViewModel(await _privacyTypeRepository.GetAll());
        }
    }
}
