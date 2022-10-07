using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public class SizesViewModel : DomainsViewModel
{
    public SizesViewModel() { }

    public SizesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string PageTitle => AdminDomainItem.Sizes.Title;
}
