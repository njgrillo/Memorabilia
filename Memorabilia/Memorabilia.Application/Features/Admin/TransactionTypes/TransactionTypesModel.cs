namespace Memorabilia.Application.Features.Admin.TransactionTypes;

public class TransactionTypesModel : DomainsModel
{
    public TransactionTypesModel() { }

    public TransactionTypesModel(IEnumerable<Entity.DomainEntity> domainEntities)
        : base(domainEntities) { }

    public override string ItemTitle
        => Constant.AdminDomainItem.TransactionTypes.Item;

    public override string PageTitle
        => Constant.AdminDomainItem.TransactionTypes.Title;

    public override string RoutePrefix
        => Constant.AdminDomainItem.TransactionTypes.Page;
}
