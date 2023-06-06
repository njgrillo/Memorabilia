using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public class BatTypesViewModel : DomainsModel
{
    public BatTypesViewModel() { }

    public BatTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.BatTypes.Item;

    public override string PageTitle => AdminDomainItem.BatTypes.Title;

    public override string RoutePrefix => AdminDomainItem.BatTypes.Page;
}
