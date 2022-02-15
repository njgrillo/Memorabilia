using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class SportsViewModel : ViewModel
    {
        public SportsViewModel() { }

        public SportsViewModel(IEnumerable<Domain.Entities.Sport> sports) 
        {
            Sports = sports.Select(sport => new SportViewModel(sport)).ToList();
        }

        public override string ItemTitle => "Sport";

        public override string PageTitle => "Sports";

        public override string RoutePrefix => "Sports";

        public List<SportViewModel> Sports { get; set; } = new();
    }
}
