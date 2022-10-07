using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public class OrientationsViewModel : DomainsViewModel
{
    public OrientationsViewModel() { }

    public OrientationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Orientations.Item;

    public override string PageTitle => AdminDomainItem.Orientations.Title;

    public override string RoutePrefix => AdminDomainItem.Orientations.Page;
}
