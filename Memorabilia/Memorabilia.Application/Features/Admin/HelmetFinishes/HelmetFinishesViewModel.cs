using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public class HelmetFinishesViewModel : DomainsModel
{
    public HelmetFinishesViewModel() { }

    public HelmetFinishesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.HelmetFinishes.Item;

    public override string PageTitle => AdminDomainItem.HelmetFinishes.Title;

    public override string RoutePrefix => AdminDomainItem.HelmetFinishes.Page;
}
