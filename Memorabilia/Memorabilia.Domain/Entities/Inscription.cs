namespace Memorabilia.Domain.Entities;

public class Inscription : DomainIdEntity
{
    public Inscription() { }

    public Inscription(int autographId, int inscriptionTypeId, string inscriptionText)
    {
        AutographId = autographId;
        InscriptionTypeId = inscriptionTypeId;
        InscriptionText = inscriptionText;
    }        

    public int AutographId { get; private set; }

    public string InscriptionText { get; private set; }

    public int InscriptionTypeId { get; private set; }        

    public void Set(int inscriptionTypeId, string inscriptionText)
    {
        InscriptionTypeId = inscriptionTypeId;
        InscriptionText = inscriptionText;
    }
}
