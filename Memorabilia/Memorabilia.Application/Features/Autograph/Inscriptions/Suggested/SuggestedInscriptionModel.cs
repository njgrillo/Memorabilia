namespace Memorabilia.Application.Features.Autograph.Inscriptions.Suggested;

public class SuggestedInscriptionModel
{
    public Constant.InscriptionType InscriptionType { get; set; }

    public string InscriptionTypeName => InscriptionType?.Name;

    public string Text { get; set; }    
}
