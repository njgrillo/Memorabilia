using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.LevelTypes
{
    public class LevelTypesViewModel : DomainsViewModel
    {
        public LevelTypesViewModel() { }

        public LevelTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Level Type";

        public override string PageTitle => "Level Types";

        public override string RoutePrefix => "LevelTypes";
    }
}
