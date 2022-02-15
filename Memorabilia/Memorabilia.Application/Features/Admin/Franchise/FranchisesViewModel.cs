using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class FranchisesViewModel : ViewModel
    {
        public FranchisesViewModel() { }

        public FranchisesViewModel(IEnumerable<Domain.Entities.Franchise> franchises)
        {
            Franchises = franchises.Select(franchise => new FranchiseViewModel(franchise)).ToList();
        }

        public List<FranchiseViewModel> Franchises { get; set; } = new();

        public override string ItemTitle => "Franchise";

        public override string PageTitle => "Franchises";

        public override string RoutePrefix => "Franchises";
    }
}
