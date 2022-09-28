using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes
{
    public class FootballTypesViewModel : DomainsViewModel
    {
        public FootballTypesViewModel() { }

        public FootballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Football Type";

        public override string PageTitle => "Football Types";

        public override string RoutePrefix => "FootballTypes";
    }
}
