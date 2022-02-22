using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Pewter
{
    public class PewtersViewModel : ViewModel
    {
        public PewtersViewModel() { }

        public PewtersViewModel(IEnumerable<Domain.Entities.Pewter> pewters)
        {
            Pewters = pewters.Select(pewter => new PewterViewModel(pewter)).ToList();
        }

        public override string ItemTitle => "Pewter";

        public override string PageTitle => "Pewters";

        public List<PewterViewModel> Pewters { get; set; } = new();

        public override string RoutePrefix => "Pewters";
    }
}
