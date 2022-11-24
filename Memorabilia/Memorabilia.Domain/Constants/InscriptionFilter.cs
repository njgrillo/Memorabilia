namespace Memorabilia.Domain.Constants;

public sealed class InscriptionFilter : Filter<InscriptionFilter>
{
    public static readonly InscriptionFilter None = new("None");
    public static readonly InscriptionFilter NoInscription = new("No Inscriptions(s)");
    public static readonly InscriptionFilter Inscription = new("Has Inscriptions(s)");

    private InscriptionFilter(string name) : base(name) { }

    public static readonly InscriptionFilter[] All =
    {
        None,
        NoInscription,
        Inscription
    };

    public static readonly InscriptionFilter[] FilterItems =
    {
        NoInscription,
        Inscription
    };
}
