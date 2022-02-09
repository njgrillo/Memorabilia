using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.LevelType
{
    public class LevelTypesViewModel : DomainsViewModel
    {
        public LevelTypesViewModel() { }

        public LevelTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Level Types";
    }
}
