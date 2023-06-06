using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public class AwardTypesViewModel : DomainsModel
{
    public AwardTypesViewModel() { }

    public AwardTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.AwardTypes.Item;

    public override string PageTitle => AdminDomainItem.AwardTypes.Title;

    public override string RoutePrefix => AdminDomainItem.AwardTypes.Page;
}
