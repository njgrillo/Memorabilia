using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class CommissionersViewModel : ViewModel
    {
        public CommissionersViewModel() { }

        public CommissionersViewModel(IEnumerable<Domain.Entities.Commissioner> commissioners)
        {
            Commissioners = commissioners.Select(commissioner => new CommissionerViewModel(commissioner)).ToList();
        }

        public List<CommissionerViewModel> Commissioners { get; set; } = new();

        public override string ItemTitle => "Commissioner";

        public override string PageTitle => "Commissioners";

        public override string RoutePrefix => "Commissioners";
    }
}
