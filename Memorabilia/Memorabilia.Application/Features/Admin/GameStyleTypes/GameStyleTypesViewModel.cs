using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public class GameStyleTypesViewModel : DomainsModel
{
    public GameStyleTypesViewModel() { }

    public GameStyleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.GameStyleTypes.Item;

    public override string PageTitle => AdminDomainItem.GameStyleTypes.Title;

    public override string RoutePrefix => AdminDomainItem.GameStyleTypes.Page;
}
