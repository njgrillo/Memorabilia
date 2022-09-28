using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes
{
    public class GameStyleTypesViewModel : DomainsViewModel
    {
        public GameStyleTypesViewModel() { }

        public GameStyleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Game Style Type";

        public override string PageTitle => "Game Style Types";

        public override string RoutePrefix => "GameStyleTypes";
    }
}
