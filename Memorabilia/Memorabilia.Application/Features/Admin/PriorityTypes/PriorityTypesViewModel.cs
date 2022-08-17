using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.PriorityTypes
{
    public class PriorityTypesViewModel : DomainsViewModel
    {
        public PriorityTypesViewModel() { }

        public PriorityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Priority Type";

        public override string PageTitle => "Priority Types";

        public override string RoutePrefix => "PriorityTypes";
    }
}
