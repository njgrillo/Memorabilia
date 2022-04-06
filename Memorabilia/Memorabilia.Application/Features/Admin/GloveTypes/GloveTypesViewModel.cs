using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.GloveTypes
{
    public class GloveTypesViewModel : DomainsViewModel
    {
        public GloveTypesViewModel() { }

        public GloveTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Glove Type";

        public override string PageTitle => "Glove Types";

        public override string RoutePrefix => "GloveTypes";
    }
}
