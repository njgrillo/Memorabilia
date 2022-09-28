using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes
{
    public class InscriptionTypesViewModel : DomainsViewModel
    {
        public InscriptionTypesViewModel() { }

        public InscriptionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Inscription Type";

        public override string PageTitle => "Inscription Types";

        public override string RoutePrefix => "InscriptionTypes";
    }
}
