using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public class PrivacyTypesViewModel : DomainsModel
{
    public PrivacyTypesViewModel() { }

    public PrivacyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.PrivacyTypes.Item;

    public override string PageTitle => AdminDomainItem.PrivacyTypes.Title;

    public override string RoutePrefix => AdminDomainItem.PrivacyTypes.Page;
}
