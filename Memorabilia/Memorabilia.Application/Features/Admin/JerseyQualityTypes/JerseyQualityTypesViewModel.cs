using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public class JerseyQualityTypesViewModel : DomainsViewModel
{
    public JerseyQualityTypesViewModel() { }

    public JerseyQualityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.JerseyQualityTypes.Item;

    public override string PageTitle => AdminDomainItem.JerseyQualityTypes.Title;

    public override string RoutePrefix => AdminDomainItem.JerseyQualityTypes.Page;
}
