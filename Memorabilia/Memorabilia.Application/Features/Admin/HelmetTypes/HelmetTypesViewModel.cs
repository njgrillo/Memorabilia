using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities; 

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public class HelmetTypesViewModel : DomainsModel
{
    public HelmetTypesViewModel() { }

    public HelmetTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.HelmetTypes.Item;

    public override string PageTitle => AdminDomainItem.HelmetTypes.Title;

    public override string RoutePrefix => AdminDomainItem.HelmetTypes.Page;
}
