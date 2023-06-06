using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public class ColorsViewModel : DomainsModel
{
    public ColorsViewModel() { }

    public ColorsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Colors.Item;

    public override string PageTitle => AdminDomainItem.Colors.Title;

    public override string RoutePrefix => AdminDomainItem.Colors.Page;
}
