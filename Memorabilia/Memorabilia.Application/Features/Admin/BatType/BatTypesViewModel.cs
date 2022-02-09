using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.BatType
{
    public class BatTypesViewModel : DomainsViewModel
    {
        public BatTypesViewModel() { }

        public BatTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Bat Types";
    }
}
