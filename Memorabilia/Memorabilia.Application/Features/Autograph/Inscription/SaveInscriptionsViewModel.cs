using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Inscription
{
    public class SaveInscriptionsViewModel : ViewModel
    {
        public SaveInscriptionsViewModel() { }

        public SaveInscriptionsViewModel(IEnumerable<Domain.Entities.Inscription> inscriptions)
        {
            Inscriptions = inscriptions.Select(inscription => new SaveInscriptionViewModel(new InscriptionViewModel(inscription))).ToList();
        }

        public int AutographId { get; set; }

        public string ImagePath => "images/inscriptiontypes.jpg";

        public List<SaveInscriptionViewModel> Inscriptions { get; set; } = new();

        public override string PageTitle => "Inscriptions";
    }
}
