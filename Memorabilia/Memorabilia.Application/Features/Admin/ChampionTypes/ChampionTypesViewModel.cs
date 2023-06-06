using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public class ChampionTypesViewModel : DomainsModel
{
    public ChampionTypesViewModel() { }

    public ChampionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.ChampionTypes.Item;

    public override string PageTitle => AdminDomainItem.ChampionTypes.Title;

    public override string RoutePrefix => AdminDomainItem.ChampionTypes.Page;
}
