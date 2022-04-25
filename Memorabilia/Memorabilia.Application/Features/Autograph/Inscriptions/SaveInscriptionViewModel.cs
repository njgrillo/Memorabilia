namespace Memorabilia.Application.Features.Autograph.Inscriptions
{
    public class SaveInscriptionViewModel : SaveViewModel
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

        public string InscriptionText { get; set; }

        public int InscriptionTypeId { get; set; }

        public string InscriptionTypeName => Domain.Constants.InscriptionType.Find(InscriptionTypeId)?.Name;

        public Domain.Constants.InscriptionType[] InscriptionTypes => Domain.Constants.InscriptionType.All;
    }
}
