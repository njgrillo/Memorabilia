using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes
{
    public class AccomplishmentTypesViewModel : DomainsViewModel
    {
        public AccomplishmentTypesViewModel() { }

        public AccomplishmentTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Accomplishment Type";

        public override string PageTitle => "Accomplishment Types";

        public override string RoutePrefix => "AccomplishmentTypes";
    }
}
