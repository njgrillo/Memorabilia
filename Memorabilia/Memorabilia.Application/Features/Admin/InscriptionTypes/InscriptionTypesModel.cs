namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public class InscriptionTypesModel : DomainsModel
{
    public InscriptionTypesModel() { }

    public InscriptionTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.InscriptionTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.InscriptionTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.InscriptionTypes.Page;
}
