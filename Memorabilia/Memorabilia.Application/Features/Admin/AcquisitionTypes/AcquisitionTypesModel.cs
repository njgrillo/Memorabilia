namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public class AcquisitionTypesModel : DomainsModel
{
    public AcquisitionTypesModel() { }

    public AcquisitionTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle
        => Constant.AdminDomainItem.AcquisitionTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.AcquisitionTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.AcquisitionTypes.Page;
}
