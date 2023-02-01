using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.CerealTypes;

public class CerealTypesViewModel : DomainsViewModel
{
    public CerealTypesViewModel() { }

    public CerealTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.CerealTypes.Item;

    public override string PageTitle => AdminDomainItem.CerealTypes.Title;

    public override string RoutePrefix => AdminDomainItem.CerealTypes.Page;
}
