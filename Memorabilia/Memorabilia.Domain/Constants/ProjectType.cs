namespace Memorabilia.Domain.Constants;

public sealed class ProjectType : DomainItemConstant
{
    public static readonly ProjectType BaseballType = new(1, "Baseball Type", "A project based on a baseball type.");
    public static readonly ProjectType Card = new(2, "Card", "A project based on a card set.");
    public static readonly ProjectType HallOfFame = new(3, "Hall of Fame", "A project based on Hall of Famers.");
    public static readonly ProjectType HelmetType = new(4, "Helmet Type", "A project based on a helmet type.");
    public static readonly ProjectType ItemType = new(5, "Item Type", "A project based on an item type.");
    public static readonly ProjectType MultiSignedItemType = new(6, "Multi Signed Item Type", "A project based on an item type signed by multiple people.");
    public static readonly ProjectType Team = new(7, "Team", "A project based on a team.");
    public static readonly ProjectType WorldSeries = new(8, "World Series", "A project based on a World Series.");

    public static readonly ProjectType[] All =
    {
        BaseballType,
        Card,
        HallOfFame,
        HelmetType,
        ItemType,
        MultiSignedItemType,
        Team,
        WorldSeries
    };

    public static readonly ProjectType[] PersonProject =
    {
        BaseballType,
        Card,
        HallOfFame,
        ItemType
    };

    public static readonly ProjectType[] TeamProject =
    {
        HelmetType,
        Team,
        WorldSeries
    };

    private ProjectType(int id, string name, string description, string abbreviation = null) 
        : base(id, name, abbreviation) 
    { 
        Description = description;
    }

    public static ProjectType Find(int id)
        => All.SingleOrDefault(projectType => projectType.Id == id);

    public string Description { get; set; }

    public override string ToString()
    {
        return Name.Replace(" ", "");
    }
}
