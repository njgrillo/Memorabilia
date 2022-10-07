using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public class GloveTypesViewModel : DomainsViewModel
{
    public GloveTypesViewModel() { }

    public GloveTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.GloveTypes.Item;

    public override string PageTitle => AdminDomainItem.GloveTypes.Title;

    public override string RoutePrefix => AdminDomainItem.GloveTypes.Page;
}
