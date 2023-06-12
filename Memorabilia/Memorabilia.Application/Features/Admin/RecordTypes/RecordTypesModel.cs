namespace Memorabilia.Application.Features.Admin.RecordTypes;

public class RecordTypesModel : DomainsModel
{
    public RecordTypesModel() { }

    public RecordTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.RecordTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.RecordTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.RecordTypes.Page;
}
