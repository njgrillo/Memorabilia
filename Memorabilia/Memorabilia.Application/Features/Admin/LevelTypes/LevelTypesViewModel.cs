using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public class LevelTypesViewModel : DomainsViewModel
{
    public LevelTypesViewModel() { }

    public LevelTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.LevelTypes.Item;

    public override string PageTitle => AdminDomainItem.LevelTypes.Title;

    public override string RoutePrefix => AdminDomainItem.LevelTypes.Page;
}
