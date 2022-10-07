using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public class InscriptionTypesViewModel : DomainsViewModel
{
    public InscriptionTypesViewModel() { }

    public InscriptionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.InscriptionTypes.Item;

    public override string PageTitle => AdminDomainItem.InscriptionTypes.Title;

    public override string RoutePrefix => AdminDomainItem.InscriptionTypes.Page;
}
