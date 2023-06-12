namespace Memorabilia.Domain.Extensions;

public static class PersonExtensions
{
    public static Entity.Champion[] Championships(this List<Entity.PersonTeam> teams, 
                                                  Constant.Sport sport = null,
                                                  Constant.Occupation occupation = null)
    {
        Entity.PersonTeam[] teamsFiltered = teams.Filter(sport, occupation);

        return teamsFiltered.SelectMany(team => team.Team.Championships)
                            .Where(championship => teamsFiltered.Any(team => team.TeamId == championship.TeamId && team.BeginYear <= championship.Year && (!team.EndYear.HasValue || team.EndYear >= championship.Year)))
                            .DistinctBy(championship => new { championship.TeamId, championship.Year })
                            .ToArray();
    }

    public static bool HasChampionships(this List<Entity.PersonTeam> teams, 
                                        Constant.Sport sport = null,
                                        Constant.Occupation occupation = null)
        => Championships(teams, sport, occupation).Any();

    public static bool HasService(this Entity.SportService service)
        => service != null&& 
           (service.FreeAgentSigningDate.HasValue || 
            service.DebutDate.HasValue || 
            service.LastAppearanceDate.HasValue);

    public static Entity.PersonTeam[] Filter(this List<Entity.PersonTeam> teams, 
                                             Constant.Sport sport = null,
                                             Constant.Occupation occupation = null)
    {
        Constant.TeamRoleType[] validTeamRoleTypes = occupation != null
            ? Constant.TeamRoleType.ValidTypes(occupation)
            : Array.Empty<Constant.TeamRoleType>();

        return teams.Where(team => (sport == null || sport.Id == team.Team.Franchise.SportLeagueLevel.SportId) && 
                                   (occupation == null || validTeamRoleTypes.Contains(Constant.TeamRoleType.Find(team.TeamRoleTypeId))))
                    .ToArray();
    }

    public static Entity.PersonAccomplishment[] Filter(this List<Entity.PersonAccomplishment> accomplishments, 
                                                       Constant.Sport sport = null,
                                                       Constant.Occupation occupation = null)
    {
        if (occupation != null && occupation != Constant.Occupation.Athlete)
            return Array.Empty<Entity.PersonAccomplishment>();

        Constant.AccomplishmentType[] validTypes = sport != null
            ? Constant.AccomplishmentType.GetAll(sport)
            : Array.Empty<Constant.AccomplishmentType>();

        return accomplishments.Where(accomplishment => sport == null || 
                                     validTypes.Contains(Constant.AccomplishmentType.Find(accomplishment.AccomplishmentTypeId)))
                              .ToArray();
    }

    public static Entity.AllStar[] Filter(this List<Entity.AllStar> allStars, 
                                          Constant.Sport sport = null,
                                          Constant.Occupation occupation = null)
    {
        if (occupation != null && 
            occupation != Constant.Occupation.Athlete)
            return Array.Empty<Entity.AllStar>();

        return allStars.Where(allStar => sport == null || 
                              sport.Id == allStar.SportId)
                       .ToArray();
    }

    public static Entity.Draft[] Filter(this List<Entity.Draft> drafts, 
                                        Constant.Sport sport = null)
        => drafts.Where(draft => sport == null || 
                        draft.Franchise.SportLeagueLevel.SportId == sport.Id)
                 .ToArray();

    public static Entity.PersonAward[] Filter(this List<Entity.PersonAward> awards, 
                                              Constant.Sport sport = null,
                                              Constant.Occupation occupation = null)
    {
        Constant.AwardType[] validTypes = Array.Empty<Constant.AwardType>();

        if (sport != null && occupation != null)
            validTypes = Constant.AwardType.GetAll(sport, occupation);

        return awards.Where(award => sport == null || 
                            validTypes.Contains(Constant.AwardType.Find(award.AwardTypeId)))
                     .ToArray();
    }

    public static Entity.HallOfFame[] Filter(this List<Entity.HallOfFame> hallOfFames, 
                                             Constant.Sport sport = null)
        => hallOfFames.Where(hof => sport == null || 
                             sport.Id == Constant.SportLeagueLevel.Find(hof.SportLeagueLevelId).Sport.Id)
                      .ToArray();

    public static Entity.FranchiseHallOfFame[] Filter(this List<Entity.FranchiseHallOfFame> hallOfFames, 
                                                      Constant.Sport sport = null)
        => hallOfFames.Where(hof => sport == null || 
                             sport.Id == hof.Franchise.SportLeagueLevel.SportId)
                      .ToArray();

    public static Entity.Leader[] Filter(this List<Entity.Leader> leaders, 
                                         Constant.Sport sport = null,
                                         Constant.Occupation occupation = null)
    {
        if (occupation != null && 
            occupation != Constant.Occupation.Athlete)
            return Array.Empty<Entity.Leader>();   

        Constant.LeaderType[] validTypes = sport != null
            ? Constant.LeaderType.GetAll(sport)
            : Array.Empty<Constant.LeaderType>();

        return leaders.Where(leader => sport == null || 
                             validTypes.Contains(Constant.LeaderType.Find(leader.LeaderTypeId)))
                      .ToArray();
    }

    public static Entity.PersonPosition[] Filter(this List<Entity.PersonPosition> positions, 
                                                 Constant.Sport sport = null)
        => positions.Where(position => sport == null || 
                           position.Position.SportId == sport.Id)
                    .ToArray();

    public static Entity.CareerRecord[] Filter(this List<Entity.CareerRecord> careerRecords, 
                                               Constant.Sport sport = null,
                                               Constant.Occupation occupation = null)
    {
        //TODO: Filter by occupation

        Constant.RecordType[] validTypes = sport != null
            ? Constant.RecordType.GetAll(sport)
            : Array.Empty<Constant.RecordType>();

        return careerRecords.Where(record => sport == null || 
                                   validTypes.Contains(Constant.RecordType.Find(record.RecordTypeId)))
                            .ToArray();
    }

    public static Entity.SingleSeasonRecord[] Filter(this List<Entity.SingleSeasonRecord> singleSeasonRecords, 
                                                     Constant.Sport sport = null)
    {
        Constant.RecordType[] validTypes 
            = sport != null
                ? Constant.RecordType.GetAll(sport)
                : Array.Empty<Constant.RecordType>();

        return singleSeasonRecords.Where(record => sport == null || 
                                         validTypes.Contains(Constant.RecordType.Find(record.RecordTypeId)))
                                  .ToArray();
    }
}
