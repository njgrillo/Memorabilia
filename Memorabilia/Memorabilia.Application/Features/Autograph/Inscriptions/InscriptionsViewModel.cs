using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Inscriptions
{
    public class InscriptionsViewModel : ViewModel
    {
        public InscriptionsViewModel() { }

        public InscriptionsViewModel(IEnumerable<Inscription> inscriptions)
        {
            Inscriptions = inscriptions.Select(inscription => new InscriptionViewModel(inscription)).ToList();
        }

        public int AutographId { get; set; }

        public string ImagePath { get; set; }

        public List<InscriptionViewModel> Inscriptions { get; set; } = new();

        public override string PageTitle => "Inscriptions";
    }
}
