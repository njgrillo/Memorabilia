using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Pewters
{
    public class PewtersViewModel : ViewModel
    {
        public PewtersViewModel() { }

        public PewtersViewModel(IEnumerable<Pewter> pewters)
        {
            Pewters = pewters.Select(pewter => new PewterViewModel(pewter)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Pewter";

        public override string PageTitle => "Pewters";

        public List<PewterViewModel> Pewters { get; set; } = new();

        public override string RoutePrefix => "Pewters";
    }
}
