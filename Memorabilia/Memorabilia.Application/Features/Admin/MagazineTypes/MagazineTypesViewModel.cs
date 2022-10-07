using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public class MagazineTypesViewModel : DomainsViewModel
{
    public MagazineTypesViewModel() { }

    public MagazineTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.MagazineTypes.Item;

    public override string PageTitle => AdminDomainItem.MagazineTypes.Title;

    public override string RoutePrefix => AdminDomainItem.MagazineTypes.Page;
}
