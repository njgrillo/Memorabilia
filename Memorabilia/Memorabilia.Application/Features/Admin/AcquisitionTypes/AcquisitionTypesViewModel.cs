using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public class AcquisitionTypesViewModel : DomainsViewModel
{
    public AcquisitionTypesViewModel() { }

    public AcquisitionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.AcquisitionTypes.Item;

    public override string PageTitle => AdminDomainItem.AcquisitionTypes.Title;

    public override string RoutePrefix => AdminDomainItem.AcquisitionTypes.Page;
}
