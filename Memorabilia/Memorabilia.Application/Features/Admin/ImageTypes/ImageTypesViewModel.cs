using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public class ImageTypesViewModel : DomainsModel
{
    public ImageTypesViewModel() { }

    public ImageTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.ImageTypes.Item;

    public override string PageTitle => AdminDomainItem.ImageTypes.Title;

    public override string RoutePrefix => AdminDomainItem.ImageTypes.Page;
}
