using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyType
{
    public class FigureSpecialtyTypesViewModel : DomainsViewModel
    {
        public FigureSpecialtyTypesViewModel() { }

        public FigureSpecialtyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Figure Specialty Type";

        public override string PageTitle => "Figure Specialty Types";

        public override string RoutePrefix => "FigureSpecialtyTypes";
    }
}
