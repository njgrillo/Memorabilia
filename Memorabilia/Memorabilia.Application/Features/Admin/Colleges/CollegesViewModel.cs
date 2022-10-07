using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public class CollegesViewModel : DomainsViewModel
{
    public CollegesViewModel() { }

    public CollegesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Colleges.Item;

    public override string PageTitle => AdminDomainItem.Colleges.Title;

    public override string RoutePrefix => AdminDomainItem.Colleges.Page;
}
