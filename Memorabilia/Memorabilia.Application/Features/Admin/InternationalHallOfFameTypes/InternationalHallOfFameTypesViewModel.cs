using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public class InternationalHallOfFameTypesViewModel : DomainsViewModel
{
    public InternationalHallOfFameTypesViewModel() { }

    public InternationalHallOfFameTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.InternationalHallOfFameTypes.Item;

    public override string PageTitle => AdminDomainItem.InternationalHallOfFameTypes.Title;

    public override string RoutePrefix => AdminDomainItem.InternationalHallOfFameTypes.Page;
}
