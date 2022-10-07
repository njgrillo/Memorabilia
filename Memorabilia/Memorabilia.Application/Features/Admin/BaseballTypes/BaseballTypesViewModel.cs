using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public class BaseballTypesViewModel : DomainsViewModel
{
    public BaseballTypesViewModel() { }

    public BaseballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.BaseballTypes.Item;

    public override string PageTitle => AdminDomainItem.BaseballTypes.Title;

    public override string RoutePrefix => AdminDomainItem.BaseballTypes.Page;
}