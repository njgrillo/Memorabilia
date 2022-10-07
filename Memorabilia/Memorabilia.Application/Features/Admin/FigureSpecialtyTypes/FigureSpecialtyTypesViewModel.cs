using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public class FigureSpecialtyTypesViewModel : DomainsViewModel
{
    public FigureSpecialtyTypesViewModel() { }

    public FigureSpecialtyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.FigureSpecialtyTypes.Item;

    public override string PageTitle => AdminDomainItem.FigureSpecialtyTypes.Title;

    public override string RoutePrefix => AdminDomainItem.FigureSpecialtyTypes.Page;
}
