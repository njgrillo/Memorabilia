using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public class HelmetQualityTypesViewModel : DomainsViewModel
{
    public HelmetQualityTypesViewModel() { }

    public HelmetQualityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.HelmetQualityTypes.Item;

    public override string PageTitle => AdminDomainItem.HelmetQualityTypes.Title;

    public override string RoutePrefix => AdminDomainItem.HelmetQualityTypes.Page;
}