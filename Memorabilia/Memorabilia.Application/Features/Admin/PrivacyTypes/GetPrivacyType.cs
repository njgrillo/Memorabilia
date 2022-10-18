using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetPrivacyType, DomainViewModel>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetPrivacyType query)
        {
            return new DomainViewModel(await _privacyTypeRepository.Get(query.Id));
        }
    }
}
