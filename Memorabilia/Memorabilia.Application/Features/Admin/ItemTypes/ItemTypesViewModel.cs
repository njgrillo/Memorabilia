using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public class ItemTypesViewModel : DomainsViewModel
{
    public ItemTypesViewModel() { }

    public ItemTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.ItemTypes.Item;

    public override string PageTitle => AdminDomainItem.ItemTypes.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypes.Page;
}