using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public class BammerTypesViewModel : DomainsModel
{
    public BammerTypesViewModel() { }

    public BammerTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.BammerTypes.Item;

    public override string PageTitle => AdminDomainItem.BammerTypes.Title;

    public override string RoutePrefix => AdminDomainItem.BammerTypes.Page;
}
