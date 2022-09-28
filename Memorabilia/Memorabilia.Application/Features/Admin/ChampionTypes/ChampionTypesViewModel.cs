using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes
{
    public class ChampionTypesViewModel : DomainsViewModel
    {
        public ChampionTypesViewModel() { }

        public ChampionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Champion Type";

        public override string PageTitle => "Champion Types";

        public override string RoutePrefix => "ChampionTypes";
    }
}
