using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public class WritingInstrumentsViewModel : DomainsViewModel
{
    public WritingInstrumentsViewModel() { }

    public WritingInstrumentsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.WritingInstruments.Item;

    public override string PageTitle => AdminDomainItem.WritingInstruments.Title;

    public override string RoutePrefix => AdminDomainItem.WritingInstruments.Page;
}
