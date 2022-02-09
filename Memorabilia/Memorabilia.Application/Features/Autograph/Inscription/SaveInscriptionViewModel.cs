namespace Memorabilia.Application.Features.Autograph.Inscription
{
    public class SaveInscriptionViewModel
    {
        public SaveInscriptionViewModel() { }

        public SaveInscriptionViewModel(Domain.Entities.Inscription inscription)
        {
            AutographId = inscription.AutographId;
            Id = inscription.Id;
            InscriptionText = inscription.Text;
            InscriptionTypeId = inscription.InscriptionTypeId;
        }

        public int AutographId { get; set; }

        public int Id { get; set; }

        public string InscriptionText { get; set; }

        public int InscriptionTypeId { get; set; }
    }
}
