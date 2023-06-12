namespace Memorabilia.Application.Features.Admin.FigureTypes;

public class FigureTypesModel : DomainsModel
{
    public FigureTypesModel() { }

    public FigureTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.FigureTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.FigureTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.FigureTypes.Page;
}
