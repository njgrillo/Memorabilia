using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands
{
    public class BrandsViewModel : DomainsViewModel
    {
        public BrandsViewModel() { }

        public BrandsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Brand";

        public override string PageTitle => "Brands";

        public override string RoutePrefix => "Brands";
    }
}
