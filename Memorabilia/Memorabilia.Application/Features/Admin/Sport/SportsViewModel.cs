using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class SportsViewModel : ViewModel
    {
        public SportsViewModel() { }

        public SportsViewModel(IEnumerable<Domain.Entities.Sport> sports) 
        {
            Sports = sports.Select(sport => new SportViewModel(sport));
        }

        public override string PageTitle => "Sports";

        public IEnumerable<SportViewModel> Sports { get; set; } = Enumerable.Empty<SportViewModel>();
    }
}
