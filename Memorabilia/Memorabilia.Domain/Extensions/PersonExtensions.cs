using Memorabilia.Domain.Entities;

namespace Memorabilia.Domain.Extensions;

public static class PersonExtensions
{
    public static Champion[] Championships(this List<PersonTeam> teams, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        PersonTeam[] teamsFiltered = teams.Filter(sport, occupation);

        return teamsFiltered.SelectMany(team => team.Team.Championships)
                            .Where(championship => teamsFiltered.Any(team => team.TeamId == championship.TeamId && team.BeginYear <= championship.Year && (!team.EndYear.HasValue || team.EndYear >= championship.Year)))
                            .DistinctBy(championship => new { championship.TeamId, championship.Year })
                            .ToArray();
    }

    public static bool HasChampionships(this List<PersonTeam> teams, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        return Championships(teams, sport, occupation).Any();
    }

    public static bool HasService(this SportService service)
    {
        return service != null
            && (service.FreeAgentSigningDate.HasValue
                || service.DebutDate.HasValue
                || service.LastAppearanceDate.HasValue);
    }

    public static PersonTeam[] Filter(this List<PersonTeam> teams, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        Constants.TeamRoleType[] validTeamRoleTypes = occupation != null
            ? Constants.TeamRoleType.ValidTypes(occupation)
            : Array.Empty<Constants.TeamRoleType>();

        return teams.Where(team => (sport == null || sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                                && (occupation == null || validTeamRoleTypes.Contains(Constants.TeamRoleType.Find(team.TeamRoleTypeId))))
                    .ToArray();
    }

    public static PersonAccomplishment[] Filter(this List<PersonAccomplishment> accomplishments, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        if (occupation != null && occupation != Constants.Occupation.Athlete)
            return Array.Empty<PersonAccomplishment>();

        Constants.AccomplishmentType[] validTypes = sport != null
            ? Constants.AccomplishmentType.GetAll(sport)
            : Array.Empty<Constants.AccomplishmentType>();

        return accomplishments.Where(accomplishment => sport == null || validTypes.Contains(Constants.AccomplishmentType.Find(accomplishment.AccomplishmentTypeId)))
                              .ToArray();
    }

    public static AllStar[] Filter(this List<AllStar> allStars, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        if (occupation != null && occupation != Constants.Occupation.Athlete)
            return Array.Empty<AllStar>();

        return allStars.Where(allStar => sport == null || sport.Id == allStar.SportId)
                       .ToArray();
    }

    public static Draft[] Filter(this List<Draft> drafts, 
        Constants.Sport sport = null)
    {
        return drafts.Where(draft => sport == null || draft.Franchise.SportLeagueLevel.SportId == sport.Id)
                     .ToArray();
    }

    public static PersonAward[] Filter(this List<PersonAward> awards, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        Constants.AwardType[] validTypes = Array.Empty<Constants.AwardType>();

        if (sport != null && occupation != null)
            validTypes = Constants.AwardType.GetAll(sport, occupation);

        return awards.Where(award => sport == null || validTypes.Contains(Constants.AwardType.Find(award.AwardTypeId)))
                     .ToArray();
    }

    public static HallOfFame[] Filter(this List<HallOfFame> hallOfFames, 
        Constants.Sport sport = null)
    {
        return hallOfFames.Where(hof => sport == null || sport.Id == Constants.SportLeagueLevel.Find(hof.SportLeagueLevelId).Sport.Id)
                          .ToArray();
    }

    public static FranchiseHallOfFame[] Filter(this List<FranchiseHallOfFame> hallOfFames, 
        Constants.Sport sport = null)
    {
        return hallOfFames.Where(hof => sport == null || sport.Id == hof.Franchise.SportLeagueLevel.SportId)
                          .ToArray();
    }

    public static Leader[] Filter(this List<Leader> leaders, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        if (occupation != null && occupation != Constants.Occupation.Athlete)
            return Array.Empty<Leader>();   

        Constants.LeaderType[] validTypes = sport != null
            ? Constants.LeaderType.GetAll(sport)
            : Array.Empty<Constants.LeaderType>();

        return leaders.Where(leader => sport == null || validTypes.Contains(Constants.LeaderType.Find(leader.LeaderTypeId)))
                      .ToArray();
    }

    public static PersonPosition[] Filter(this List<PersonPosition> positions, 
        Constants.Sport sport = null)
    {
        return positions.Where(position => sport == null || position.Position.SportId == sport.Id)
                        .ToArray();
    }

    public static CareerRecord[] Filter(this List<CareerRecord> careerRecords, 
        Constants.Sport sport = null,
        Constants.Occupation occupation = null)
    {
        //Filter by occupation

        Constants.RecordType[] validTypes = sport != null
            ? Constants.RecordType.GetAll(sport)
            : Array.Empty<Constants.RecordType>();

        return careerRecords.Where(record => sport == null || validTypes.Contains(Constants.RecordType.Find(record.RecordTypeId)))
                            .ToArray();
    }

    public static SingleSeasonRecord[] Filter(this List<SingleSeasonRecord> singleSeasonRecords, 
        Constants.Sport sport = null)
    {
        Constants.RecordType[] validTypes = sport != null
            ? Constants.RecordType.GetAll(sport)
            : Array.Empty<Constants.RecordType>();

        return singleSeasonRecords.Where(record => sport == null || validTypes.Contains(Constants.RecordType.Find(record.RecordTypeId)))
                                  .ToArray();
    }
}
