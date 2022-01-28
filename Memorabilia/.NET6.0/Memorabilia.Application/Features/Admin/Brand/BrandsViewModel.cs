using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class BrandsViewModel : DomainsViewModel
    {
        public BrandsViewModel() { }

        public BrandsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Brands";
    }
}
