using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.BammerTypes
{
    public class BammerTypesViewModel : DomainsViewModel
    {
        public BammerTypesViewModel() { }

        public BammerTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Bammer Type";

        public override string PageTitle => "Bammer Types";

        public override string RoutePrefix => "BammerTypes";
    }
}
