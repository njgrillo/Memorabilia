using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Division
{
    public class DivisionsViewModel : ViewModel
    {
        public DivisionsViewModel() { }

        public DivisionsViewModel(IEnumerable<Domain.Entities.Division> divisions)
        {
            Divisions = divisions.Select(division => new DivisionViewModel(division))
                                 .OrderBy(division => division.Name)
                                 .ToList();
        }

        public List<DivisionViewModel> Divisions { get; set; } = new();

        public override string ItemTitle => "Division";

        public override string PageTitle => "Divisions";

        public override string RoutePrefix => "Divisions";
    }
}
