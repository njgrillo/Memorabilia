using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Brand
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
