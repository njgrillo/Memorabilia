namespace Memorabilia.Domain.Constants;

public sealed class InscriptionType : DomainItemConstant
{
    public static readonly InscriptionType Accomplishment = new(10, "Accomplishment"); 
    public static readonly InscriptionType Award = new(11, "Award");
    public static readonly InscriptionType BibleVerse = new(6, "Bible Verse");
    public static readonly InscriptionType Championship = new(13, "Championship");
    public static readonly InscriptionType Draft = new(15, "Draft");
    public static readonly InscriptionType Greeting = new(8, "Greeting");
    public static readonly InscriptionType HallOfFame = new(1, "Hall of Fame", "HOF");
    public static readonly InscriptionType Nickname = new(12, "Nickname");
    public static readonly InscriptionType Number = new(3, "Number");
    public static readonly InscriptionType Other = new(18, "Other");
    public static readonly InscriptionType Statistic = new(9, "Statistic", "STAT");
    public static readonly InscriptionType Team = new(14, "Team");             

    public static readonly InscriptionType[] All =
    {
        Accomplishment,
        Award,
        BibleVerse,
        Championship,
        Draft,
        Greeting,
        HallOfFame,
        Nickname,
        Number,
        Other,
        Statistic,
        Team
    };

    private InscriptionType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static InscriptionType Find(int id)
    {
        return All.SingleOrDefault(inscriptionType => inscriptionType.Id == id);
    }    
}
