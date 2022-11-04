using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public class ProjectTypesViewModel : DomainsViewModel
{
    public ProjectTypesViewModel() { }

    public ProjectTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.ProjectTypes.Item;

    public override string PageTitle => AdminDomainItem.ProjectTypes.Title;

    public override string RoutePrefix => AdminDomainItem.ProjectTypes.Page;
}
