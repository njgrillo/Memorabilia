using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.InscriptionType
{
    public class InscriptionTypesViewModel : DomainsViewModel
    {
        public InscriptionTypesViewModel() { }

        public InscriptionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Inscription Types";
    }
}
