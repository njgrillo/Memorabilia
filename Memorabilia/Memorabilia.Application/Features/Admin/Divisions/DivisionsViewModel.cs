using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions
{
    public class DivisionsViewModel : ViewModel
    {
        public DivisionsViewModel() { }

        public DivisionsViewModel(IEnumerable<Division> divisions)
        {
            Divisions = divisions.Select(division => new DivisionViewModel(division))
                                 .OrderBy(division => division.Name)
                                 .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public List<DivisionViewModel> Divisions { get; set; } = new();

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Division";

        public override string PageTitle => "Divisions";

        public override string RoutePrefix => "Divisions";
    }
}
