namespace Memorabilia.Domain.Constants;

public sealed class ProjectType : DomainItemConstant
{
    public static readonly ProjectType Baseball = new(1, "Baseball", string.Empty);
    public static readonly ProjectType Card = new(2, "Card", string.Empty);
    public static readonly ProjectType HallOfFame = new(3, "Hall of Fame", string.Empty);
    public static readonly ProjectType Helmet = new(4, "Helmet", string.Empty);
    public static readonly ProjectType ItemType = new(5, "Item Type", string.Empty);
    public static readonly ProjectType MultiSignedItemType = new(6, "Multi Signed Item Type", string.Empty);
    public static readonly ProjectType Team = new(7, "Team", string.Empty);
    public static readonly ProjectType WorldSeries = new(8, "World Series", string.Empty);

    public static readonly ProjectType[] All =
    {
        Baseball,
        Card,
        HallOfFame,
        Helmet,
        ItemType,
        MultiSignedItemType,
        Team,
        WorldSeries
    };

    private ProjectType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static ProjectType Find(int id)
    {
        return All.SingleOrDefault(projectType => projectType.Id == id);
    }
}
