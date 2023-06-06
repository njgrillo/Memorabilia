using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public class JerseyTypesViewModel : DomainsModel
{
    public JerseyTypesViewModel() { }

    public JerseyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.JerseyTypes.Item;

    public override string PageTitle => AdminDomainItem.JerseyTypes.Title;

    public override string RoutePrefix => AdminDomainItem.JerseyTypes.Page;
}
