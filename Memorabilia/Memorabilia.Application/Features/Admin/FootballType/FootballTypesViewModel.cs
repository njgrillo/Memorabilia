using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.FootballType
{
    public class FootballTypesViewModel : DomainsViewModel
    {
        public FootballTypesViewModel() { }

        public FootballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Football Types";
    }
}
