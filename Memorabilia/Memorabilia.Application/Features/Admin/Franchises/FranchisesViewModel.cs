using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises
{
    public class FranchisesViewModel : ViewModel
    {
        public FranchisesViewModel() { }

        public FranchisesViewModel(IEnumerable<Franchise> franchises)
        {
            Franchises = franchises.Select(franchise => new FranchiseViewModel(franchise)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<FranchiseViewModel> Franchises { get; set; } = new();       

        public override string ItemTitle => "Franchise";

        public override string PageTitle => "Franchises";

        public override string RoutePrefix => "Franchises";
    }
}
