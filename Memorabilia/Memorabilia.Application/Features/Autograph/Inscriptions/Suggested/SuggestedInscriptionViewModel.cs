using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Inscriptions.Suggested;

public class SuggestedInscriptionViewModel
{
    public InscriptionType InscriptionType { get; set; }

    public string InscriptionTypeName => InscriptionType?.Name;

    public string Text { get; set; }    
}
