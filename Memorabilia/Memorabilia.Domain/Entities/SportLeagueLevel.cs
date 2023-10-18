namespace Memorabilia.Domain.Entities;

public class SportLeagueLevel : DomainIdEntity
{
    public SportLeagueLevel() { }

    public SportLeagueLevel(int sportId, int levelTypeId, string name, string abbreviation)
    {
        SportId = sportId;
        LevelTypeId = levelTypeId;
        Name = name;
        Abbreviation = abbreviation;
    }

    public string Abbreviation { get; set; }

    public string Name { get; set; }

    public int LevelTypeId { get; set; }

    public string LevelTypeName => Constants.LevelType.Find(LevelTypeId)?.Name;

    public int SportId { get; set; }

    public string SportName => Constants.Sport.Find(SportId)?.Name;

    public void Set(int sportId, int levelTypeId, string name, string abbreviation)
    {
        SportId = sportId;
        LevelTypeId = levelTypeId;
        Name = name;
        Abbreviation = abbreviation;
    }
}
