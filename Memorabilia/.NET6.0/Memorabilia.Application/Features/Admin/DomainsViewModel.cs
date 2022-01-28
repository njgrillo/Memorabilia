using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin
{
    public class DomainsViewModel : ViewModel
    {
        public DomainsViewModel() { }

        public DomainsViewModel(IEnumerable<DomainEntity> domainEntities)
        {
            DomainEntities = domainEntities.Select(domainEntity => new DomainViewModel(domainEntity));
        }

        public IEnumerable<DomainViewModel> DomainEntities { get; set; } = Enumerable.Empty<DomainViewModel>();

        public override string PageTitle => "Authentication Companies";
    }
}
