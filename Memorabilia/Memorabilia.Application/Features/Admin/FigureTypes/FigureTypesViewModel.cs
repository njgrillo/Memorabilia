using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public class FigureTypesViewModel : DomainsViewModel
{
    public FigureTypesViewModel() { }

    public FigureTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.FigureTypes.Item;

    public override string PageTitle => AdminDomainItem.FigureTypes.Title;

    public override string RoutePrefix => AdminDomainItem.FigureTypes.Page;
}
