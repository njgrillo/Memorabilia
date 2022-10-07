using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public class GetPrivacyTypes
{
    public class Handler : QueryHandler<Query, PrivacyTypesViewModel>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<PrivacyTypesViewModel> Handle(Query query)
        {
            return new PrivacyTypesViewModel(await _privacyTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<PrivacyTypesViewModel> { }
}
