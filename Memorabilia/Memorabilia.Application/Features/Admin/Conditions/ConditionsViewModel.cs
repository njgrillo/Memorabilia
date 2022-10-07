using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public class ConditionsViewModel : DomainsViewModel
{
    public ConditionsViewModel() { }

    public ConditionsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Conditions.Item;

    public override string PageTitle => AdminDomainItem.Conditions.Title;

    public override string RoutePrefix => AdminDomainItem.Conditions.Page;
}
