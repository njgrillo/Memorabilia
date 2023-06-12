namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public class WritingInstrumentsModel : DomainsModel
{
    public WritingInstrumentsModel() { }

    public WritingInstrumentsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.WritingInstruments.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.WritingInstruments.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.WritingInstruments.Page;
}
