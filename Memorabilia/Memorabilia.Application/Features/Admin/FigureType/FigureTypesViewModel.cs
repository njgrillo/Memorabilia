using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.FigureType
{
    public class FigureTypesViewModel : DomainsViewModel
    {
        public FigureTypesViewModel() { }

        public FigureTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Figure Type";

        public override string PageTitle => "Figure Types";

        public override string RoutePrefix => "FigureTypes";
    }
}
