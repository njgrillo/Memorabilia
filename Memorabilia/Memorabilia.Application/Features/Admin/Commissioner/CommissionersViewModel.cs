using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class CommissionersViewModel : ViewModel
    {
        public CommissionersViewModel() { }

        public CommissionersViewModel(IEnumerable<Domain.Entities.Commissioner> commissioners)
        {
            Commissioners = commissioners.Select(commissioner => new CommissionerViewModel(commissioner));
        }

        public IEnumerable<CommissionerViewModel> Commissioners { get; set; } = Enumerable.Empty<CommissionerViewModel>();

        public override string PageTitle => "Commissioners";
    }
}
