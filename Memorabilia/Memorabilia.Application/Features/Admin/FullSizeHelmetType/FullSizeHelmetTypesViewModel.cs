using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.FullSizeHelmetType
{
    public class FullSizeHelmetTypesViewModel : DomainsViewModel
    {
        public FullSizeHelmetTypesViewModel() { }

        public FullSizeHelmetTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Full Size Helmet Types";
    }
}