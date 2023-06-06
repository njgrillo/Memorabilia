using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public class FranchiseHallOfFameTypesViewModel : DomainsModel
{
    public FranchiseHallOfFameTypesViewModel() { }

    public FranchiseHallOfFameTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.FranchiseHallOfFameTypes.Item;

    public override string PageTitle => AdminDomainItem.FranchiseHallOfFameTypes.Title;

    public override string RoutePrefix => AdminDomainItem.FranchiseHallOfFameTypes.Page;
}
