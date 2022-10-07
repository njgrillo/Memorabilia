using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionViewModel
{
    private readonly Inscription _inscription;

    public InscriptionViewModel() { }

    public InscriptionViewModel(Domain.Entities.Inscription inscription)
    {
        _inscription = inscription;
    }

    public int AutographId => _inscription.AutographId;

    public int Id => _inscription.Id;

    public string InscriptionText => _inscription.InscriptionText;

    public int InscriptionTypeId => _inscription.InscriptionTypeId;

    public string InscriptionTypeName => Domain.Constants.InscriptionType.Find(InscriptionTypeId)?.Name;
}
