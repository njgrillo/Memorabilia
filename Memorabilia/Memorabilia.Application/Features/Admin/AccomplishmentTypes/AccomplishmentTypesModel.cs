namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public class AccomplishmentTypesModel : DomainsViewModel
{
    public AccomplishmentTypesModel() { }

    public AccomplishmentTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => Constant.AdminDomainItem.AccomplishmentTypes.Item;

    public override string PageTitle => Constant.AdminDomainItem.AccomplishmentTypes.Title;

    public override string RoutePrefix => Constant.AdminDomainItem.AccomplishmentTypes.Page;
}
