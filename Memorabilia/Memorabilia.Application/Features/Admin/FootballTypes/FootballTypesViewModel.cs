using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public class FootballTypesViewModel : DomainsModel
{
    public FootballTypesViewModel() { }

    public FootballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.FootballTypes.Item;

    public override string PageTitle => AdminDomainItem.FootballTypes.Title;

    public override string RoutePrefix => AdminDomainItem.FootballTypes.Page;
}
