namespace Memorabilia.Domain.Extensions;

public static class PersonExtensions
{
    public static Entities.Champion[] Championships(this List<Entities.PersonTeam> teams, 
                                                    Constant.Sport sport = null,
                                                    Constant.Occupation occupation = null)
    {
        Entities.PersonTeam[] teamsFiltered = teams.Filter(sport, occupation);

        return teamsFiltered.SelectMany(team => team.Team.Championships)
                            .Where(championship => teamsFiltered.Any(team => team.TeamId == championship.TeamId && team.BeginYear <= championship.Year && (!team.EndYear.HasValue || team.EndYear >= championship.Year)))
                            .DistinctBy(championship => new { championship.TeamId, championship.Year })
                            .ToArray();
    }

    public static bool HasChampionships(this List<Entities.PersonTeam> teams, 
                                        Constant.Sport sport = null,
                                        Constant.Occupation occupation = null)
        => Championships(teams, sport, occupation).HasAny();

    public static bool HasService(this Entities.SportService service)
        => service != null && 
           (service.FreeAgentSigningDate.HasValue || 
            service.DebutDate.HasValue || 
            service.LastAppearanceDate.HasValue);

    public static Entities.PersonTeam[] Filter(this List<Entities.PersonTeam> teams, 
                                               Constant.Sport sport = null,
                                               Constant.Occupation occupation = null)
    {
        Constant.TeamRoleType[] validTeamRoleTypes = occupation != null
            ? Constant.TeamRoleType.ValidTypes(occupation)
            : [];

        return teams.Where(team => (sport == null || sport.Id == team.Team.Franchise.SportLeagueLevel.SportId) && 
                                   (occupation == null || validTeamRoleTypes.Contains(Constant.TeamRoleType.Find(team.TeamRoleTypeId))))
                    .ToArray();
    }

    public static Entities.PersonAccomplishment[] Filter(this List<Entities.PersonAccomplishment> accomplishments, 
                                                         Constant.Sport sport = null,
                                                         Constant.Occupation occupation = null)
    {
        if (occupation != null && occupation != Constant.Occupation.Athlete)
            return [];

        Constant.AccomplishmentType[] validTypes = sport != null
            ? Constant.AccomplishmentType.GetAll(sport)
            : [];

        return accomplishments.Where(accomplishment => sport == null || 
                                     validTypes.Contains(Constant.AccomplishmentType.Find(accomplishment.AccomplishmentTypeId)))
                              .ToArray();
    }

    public static Entities.AllStar[] Filter(this List<Entities.AllStar> allStars, 
                                            Constant.Sport sport = null,
                                            Constant.Occupation occupation = null)
    {
        if (occupation != null && 
            occupation != Constant.Occupation.Athlete)
            return [];

        return allStars.Where(allStar => sport == null || 
                              sport.Id == allStar.SportId)
                       .ToArray();
    }

    public static Entities.Draft[] Filter(this List<Entities.Draft> drafts, 
                                          Constant.Sport sport = null)
        => drafts.Where(draft => sport == null || 
                        draft.Franchise.SportLeagueLevel.SportId == sport.Id)
                 .ToArray();

    public static Entities.PersonAward[] Filter(this List<Entities.PersonAward> awards, 
                                                Constant.Sport sport = null,
                                                Constant.Occupation occupation = null)
    {
        Constant.AwardType[] validTypes = [];

        if (sport != null && occupation != null)
            validTypes = Constant.AwardType.GetAll(sport, occupation);

        return awards.Where(award => sport == null || 
                            validTypes.Contains(Constant.AwardType.Find(award.AwardTypeId)))
                     .ToArray();
    }

    public static Entities.HallOfFame[] Filter(this List<Entities.HallOfFame> hallOfFames, 
                                               Constant.Sport sport = null)
        => hallOfFames.Where(hof => sport == null || 
                             sport.Id == Constant.SportLeagueLevel.Find(hof.SportLeagueLevelId).Sport.Id)
                      .ToArray();

    public static Entities.FranchiseHallOfFame[] Filter(this List<Entities.FranchiseHallOfFame> hallOfFames, 
                                                        Constant.Sport sport = null)
        => hallOfFames.Where(hof => sport == null || 
                             sport.Id == hof.Franchise.SportLeagueLevel.SportId)
                      .ToArray();

    public static Entities.Leader[] Filter(this List<Entities.Leader> leaders, 
                                           Constant.Sport sport = null,
                                           Constant.Occupation occupation = null)
    {
        if (occupation != null && 
            occupation != Constant.Occupation.Athlete)
            return [];   

        Constant.LeaderType[] validTypes = sport != null
            ? Constant.LeaderType.GetAll(sport)
            : [];

        return leaders.Where(leader => sport == null || 
                             validTypes.Contains(Constant.LeaderType.Find(leader.LeaderTypeId)))
                      .ToArray();
    }

    public static Entities.PersonPosition[] Filter(this List<Entities.PersonPosition> positions, 
                                                   Constant.Sport sport = null)
        => positions.Where(position => sport == null || 
                           position.Position.SportId == sport.Id)
                    .ToArray();

    public static Entities.CareerRecord[] Filter(this List<Entities.CareerRecord> careerRecords, 
                                                 Constant.Sport sport = null,
                                                 Constant.Occupation occupation = null)
    {
        //TODO: Filter by occupation

        Constant.RecordType[] validTypes = sport != null
            ? Constant.RecordType.GetAll(sport)
            : [];

        return careerRecords.Where(record => sport == null || 
                                   validTypes.Contains(Constant.RecordType.Find(record.RecordTypeId)))
                            .ToArray();
    }

    public static Entities.SingleSeasonRecord[] Filter(this List<Entities.SingleSeasonRecord> singleSeasonRecords, 
                                                       Constant.Sport sport = null)
    {
        Constant.RecordType[] validTypes 
            = sport != null
                ? Constant.RecordType.GetAll(sport)
                : [];

        return singleSeasonRecords.Where(record => sport == null || 
                                         validTypes.Contains(Constant.RecordType.Find(record.RecordTypeId)))
                                  .ToArray();
    }
}
