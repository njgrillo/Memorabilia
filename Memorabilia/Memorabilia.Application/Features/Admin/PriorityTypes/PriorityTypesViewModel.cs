using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public class PriorityTypesViewModel : DomainsViewModel
{
    public PriorityTypesViewModel() { }

    public PriorityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.PriorityTypes.Item;

    public override string PageTitle => AdminDomainItem.PriorityTypes.Title;

    public override string RoutePrefix => AdminDomainItem.PriorityTypes.Page;
}
