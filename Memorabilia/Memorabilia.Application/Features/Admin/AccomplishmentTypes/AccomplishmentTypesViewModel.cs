using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public class AccomplishmentTypesViewModel : DomainsViewModel
{
    public AccomplishmentTypesViewModel() { }

    public AccomplishmentTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.AccomplishmentTypes.Item;

    public override string PageTitle => AdminDomainItem.AccomplishmentTypes.Title;

    public override string RoutePrefix => AdminDomainItem.AccomplishmentTypes.Page;
}
