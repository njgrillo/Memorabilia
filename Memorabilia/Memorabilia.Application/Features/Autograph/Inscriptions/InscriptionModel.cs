namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionModel
{
    private readonly Entity.Inscription _inscription;

    public InscriptionModel() { }

    public InscriptionModel(Entity.Inscription inscription)
    {
        _inscription = inscription;
    }

    public int AutographId 
        => _inscription.AutographId;

    public int Id 
        => _inscription.Id;

    public string InscriptionText 
        => _inscription.InscriptionText;

    public int InscriptionTypeId 
        => _inscription.InscriptionTypeId;

    public string InscriptionTypeName 
        => Constant.InscriptionType.Find(InscriptionTypeId)?.Name;
}
