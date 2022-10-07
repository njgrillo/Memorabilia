using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public class OccupationsViewModel : DomainsViewModel
{
    public OccupationsViewModel() { }

    public OccupationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Occupations.Item;

    public override string PageTitle => AdminDomainItem.Occupations.Title;

    public override string RoutePrefix => AdminDomainItem.Occupations.Page;
}
