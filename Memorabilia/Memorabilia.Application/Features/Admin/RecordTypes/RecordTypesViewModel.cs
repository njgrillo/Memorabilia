using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public class RecordTypesViewModel : DomainsViewModel
{
    public RecordTypesViewModel() { }

    public RecordTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.RecordTypes.Item;

    public override string PageTitle => AdminDomainItem.RecordTypes.Title;

    public override string RoutePrefix => AdminDomainItem.RecordTypes.Page;
}
