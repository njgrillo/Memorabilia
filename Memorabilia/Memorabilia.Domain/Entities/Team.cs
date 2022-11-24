using Memorabilia.Domain.Constants;

namespace Memorabilia.Domain.Entities;

public class Team : Framework.Library.Domain.Entity.DomainEntity, IWithName
{
    public Team() { }

    public Team(int franchiseId, 
                string name, 
                string location, 
                string nickname, 
                string abbreviation, 
                int? beginYear, 
                int? endYear, 
                string imageFileName)
    {
        FranchiseId = franchiseId;
        Name = name;
        Location = location;
        Nickname = nickname;
        Abbreviation = abbreviation;
        BeginYear = beginYear;
        EndYear = endYear;
        ImageFileName = imageFileName;
    }

    public string Abbreviation { get; private set; }

    public int? BeginYear { get; private set; }

    public virtual List<Champion> Championships { get; private set; } = new();

    public virtual List<TeamConference> Conferences { get; private set; } = new();

    public string DisplayName => Franchise != null
        ? $"{AdminDomainItem.Franchises.Item}: {Franchise.FullName}, {AdminDomainItem.Teams.Item}: {Location} {Name} ({BeginYear} - {(EndYear.HasValue ? EndYear : "current")})"
        : string.Empty;

    public virtual List<TeamDivision> Divisions { get; private set; } = new();

    public int? EndYear { get; private set; }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public string ImageFileName { get; private set; }

    public virtual List<TeamLeague> Leagues { get; private set; } = new();

    public string Location { get; private set; }

    public string Name { get; private set; }

    public string Nickname { get; private set; }

    public override string ToString()
    {
        return $"{Location} {Name}";
    }

    public void RemoveChampionships(int[] championIds)
    {
        Championships.RemoveAll(champion => championIds.Contains(champion.Id));
    }

    public void RemoveConferences(int[] teamConferenceIds)
    {
        Conferences.RemoveAll(teamConference => teamConferenceIds.Contains(teamConference.Id));
    }

    public void RemoveDivisions(int[] teamDivisionIds)
    {
        Divisions.RemoveAll(teamDivision => teamDivisionIds.Contains(teamDivision.Id));
    }

    public void RemoveLeagues(int[] teamLeagueIds)
    {
        Leagues.RemoveAll(teamLeague => teamLeagueIds.Contains(teamLeague.Id));
    }

    public void Set(string name, 
                    string location, 
                    string nickname, 
                    string abbreviation, 
                    int? beginYear, 
                    int? endYear, 
                    string imageFileName)
    {
        Name = name;
        Location = location;
        Nickname = nickname;
        Abbreviation = abbreviation;
        BeginYear = beginYear;
        EndYear = endYear;
        ImageFileName = imageFileName;
    }

    public void SetChampionship(int championId, int championTypeId, int year)
    {
        var championship = championId > 0 ? Championships.SingleOrDefault(championship => championship.Id == championId) : null;

        if (championship == null)
        {
            Championships.Add(new Champion(championTypeId, Id, year));
            return;
        }

        championship.Set(year);
    }

    public void SetConference(int teamConferenceId, int conferenceId, int? beginYear, int? endYear)
    {
        var conference =  teamConferenceId > 0 ? Conferences.SingleOrDefault(conference => conference.Id == teamConferenceId) : null;

        if (conference == null)
        {
            Conferences.Add(new TeamConference(conferenceId, Id, beginYear, endYear));
            return;
        }

        conference.Set(conferenceId, Id, beginYear, endYear);
    }

    public void SetDivision(int teamDivisionId, int divisionId, int? beginYear, int? endYear)
    {
        var division = teamDivisionId > 0 ? Divisions.SingleOrDefault(division => division.Id == teamDivisionId) : null;

        if (division == null)
        {
            Divisions.Add(new TeamDivision(divisionId, Id, beginYear, endYear));
            return;
        }

        division.Set(divisionId, Id, beginYear, endYear);
    }

    public void SetLeague(int teamLeagueId, int leagueId, int? beginYear, int? endYear)
    {
        var league = teamLeagueId > 0 ? Leagues.SingleOrDefault(league => league.Id == teamLeagueId) : null;

        if (league == null)
        {
            Leagues.Add(new TeamLeague(leagueId, Id, beginYear, endYear));
            return;
        }

        league.Set(leagueId, Id, beginYear, endYear);
    }
}
