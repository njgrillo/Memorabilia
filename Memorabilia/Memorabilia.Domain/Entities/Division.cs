namespace Memorabilia.Domain.Entities;

public class Division : Framework.Library.Domain.Entity.DomainEntity
{
    public Division() { }

    public Division(int? conferenceId, int? leagueId, string name, string abbreviation)
    {
        ConferenceId = conferenceId;
        LeagueId = leagueId;
        Name = name;
        Abbreviation = abbreviation;
    }

    public string Abbreviation { get; set; }

    public int? ConferenceId { get; set; }

    public string ConferenceName => Constants.Conference.Find(ConferenceId ?? 0)?.Name;

    public int? LeagueId { get; set; }

    public string Name { get; set; }        

    public void Set(int? conferenceId, int? leagueId, string name, string abbreviation)
    {
        ConferenceId = conferenceId;
        LeagueId = leagueId;
        Name = name;
        Abbreviation = abbreviation;
    }
}
