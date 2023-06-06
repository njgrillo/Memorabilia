using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public class JerseyStyleTypesViewModel : DomainsModel
{
    public JerseyStyleTypesViewModel() { }

    public JerseyStyleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.JerseyStyleTypes.Item;

    public override string PageTitle => AdminDomainItem.JerseyStyleTypes.Title;

    public override string RoutePrefix => AdminDomainItem.JerseyStyleTypes.Page;
}
