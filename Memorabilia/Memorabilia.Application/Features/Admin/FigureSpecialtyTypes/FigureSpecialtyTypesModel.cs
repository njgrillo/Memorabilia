namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public class FigureSpecialtyTypesModel : DomainsModel
{
    public FigureSpecialtyTypesModel() { }

    public FigureSpecialtyTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.FigureSpecialtyTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.FigureSpecialtyTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.FigureSpecialtyTypes.Page;
}
