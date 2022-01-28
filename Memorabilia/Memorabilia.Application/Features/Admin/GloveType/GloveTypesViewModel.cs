using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.GloveType
{
    public class GloveTypesViewModel : DomainsViewModel
    {
        public GloveTypesViewModel() { }

        public GloveTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Glove Types";
    }
}
