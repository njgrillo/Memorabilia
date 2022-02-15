using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.JerseyQualityType
{
    public class JerseyQualityTypesViewModel : DomainsViewModel
    {
        public JerseyQualityTypesViewModel() { }

        public JerseyQualityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Jersey Quality Type";

        public override string PageTitle => "Jersey Quality Types";

        public override string RoutePrefix => "JerseyQualityTypes";
    }
}
