using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Autograph.Inscription
{
    public class SaveInscriptionViewModel
    {
        public SaveInscriptionViewModel() { }

        public SaveInscriptionViewModel(InscriptionViewModel viewModel)
        {
            AutographId = viewModel.AutographId;
            Id = viewModel.Id;
            InscriptionText = viewModel.InscriptionText;
            InscriptionTypeId = viewModel.InscriptionTypeId;
        }

        public int AutographId { get; set; }

        public int Id { get; set; }

        public string InscriptionText { get; set; }

        public int InscriptionTypeId { get; set; }

        public string InscriptionTypeName => Domain.Constants.InscriptionType.Find(InscriptionTypeId)?.Name;
    }
}
