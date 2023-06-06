using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public class PhotoTypesViewModel : DomainsModel
{
    public PhotoTypesViewModel() { }

    public PhotoTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.PhotoTypes.Item;

    public override string PageTitle => AdminDomainItem.PhotoTypes.Title;

    public override string RoutePrefix => AdminDomainItem.PhotoTypes.Page;
}
