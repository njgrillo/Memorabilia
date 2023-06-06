using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public class ProjectStatusTypesViewModel : DomainsModel
{
    public ProjectStatusTypesViewModel() { }

    public ProjectStatusTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.ProjectStatusTypes.Item;

    public override string PageTitle => AdminDomainItem.ProjectStatusTypes.Title;

    public override string RoutePrefix => AdminDomainItem.ProjectStatusTypes.Page;
}
