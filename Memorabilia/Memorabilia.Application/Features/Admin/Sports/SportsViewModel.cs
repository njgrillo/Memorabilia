using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports
{
    public class SportsViewModel : ViewModel
    {
        public SportsViewModel() { }

        public SportsViewModel(IEnumerable<Sport> sports) 
        {
            Sports = sports.Select(sport => new SportViewModel(sport)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Sport";

        public override string PageTitle => "Sports";

        public override string RoutePrefix => "Sports";

        public List<SportViewModel> Sports { get; set; } = new();
    }
}
