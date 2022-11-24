namespace Memorabilia.Domain.Constants;

public sealed class PersonalizationFilter : Filter<PersonalizationFilter>
{
	public static readonly PersonalizationFilter None = new("None");
    public static readonly PersonalizationFilter NotPersonalized = new("Not Personalized");
    public static readonly PersonalizationFilter Personalized = new("Personalized");

    private PersonalizationFilter(string name) : base(name) { }

    public static readonly PersonalizationFilter[] All =
    {
        None,
        NotPersonalized,
        Personalized
    };

    public static readonly PersonalizationFilter[] FilterItems =
    {
        NotPersonalized,
        Personalized
    };
}
