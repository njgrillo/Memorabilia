using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class FranchisesViewModel : ViewModel
    {
        public FranchisesViewModel() { }

        public FranchisesViewModel(IEnumerable<Domain.Entities.Franchise> franchises)
        {
            Franchises = franchises.Select(franchise => new FranchiseViewModel(franchise));
        }

        public IEnumerable<FranchiseViewModel> Franchises { get; set; } = Enumerable.Empty<FranchiseViewModel>();

        public override string PageTitle => "Franchises";        
    }
}
