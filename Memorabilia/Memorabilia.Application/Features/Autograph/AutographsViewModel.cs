using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph
{
    public class AutographsViewModel : ViewModel
    {
        public AutographsViewModel() { }

        public AutographsViewModel(IEnumerable<Domain.Entities.Autograph> autographs)
        {
            Autographs = autographs.Select(autograph => new AutographViewModel(autograph));
        }

        public IEnumerable<AutographViewModel> Autographs { get; set; } = Enumerable.Empty<AutographViewModel>();

        public override string PageTitle => "Autographs";
    }
}
