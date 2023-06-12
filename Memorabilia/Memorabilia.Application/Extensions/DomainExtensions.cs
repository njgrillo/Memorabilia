namespace Memorabilia.Application.Extensions;

public static class DomainExtensions
{
    public static int[] ActiveIds(this List<PersonAccomplishmentEditModel> accomplishments)
        => accomplishments.Where(accomplishment => !accomplishment.IsDeleted)
                          .Select(accomplishment => accomplishment.Id)
                          .ToArray();

    public static int[] ActiveIds(this List<PersonAllStarEditModel> allStars)
        => allStars.Where(allStar => !allStar.IsDeleted)
                   .Select(allStar => allStar.Id)
                   .ToArray();

    public static int[] ActiveIds(this List<PersonAwardEditModel> awards)
        => awards.Where(award => !award.IsDeleted)
                 .Select(award => award.Id)
                 .ToArray();

    public static int[] ActiveIds(this List<PersonCareerRecordEditModel> careerRecords)
        => careerRecords.Where(careerRecord => !careerRecord.IsDeleted)
                        .Select(careerRecord => careerRecord.Id)
                        .ToArray();

    public static int[] ActiveIds(this List<PersonCollegeRetiredNumberEditModel> collegeRetiredNumbers)
        => collegeRetiredNumbers.Where(collegeRetiredNumber => !collegeRetiredNumber.IsDeleted)
                                .Select(collegeRetiredNumber => collegeRetiredNumber.Id)
                                .ToArray();

    public static int[] ActiveIds(this List<PersonLeaderEditModel> leaders)
       => leaders.Where(leader => !leader.IsDeleted)
                 .Select(leader => leader.Id)
                 .ToArray();

    public static int[] ActiveIds(this List<PersonEditModel> people)
        => people.Where(person => !person.IsDeleted)
                 .Select(person => person.Id)
                 .ToArray();

    public static int[] ActiveIds(this List<PersonRetiredNumberEditModel> retiredNumbers)
        => retiredNumbers.Where(retiredNumber => !retiredNumber.IsDeleted)
                         .Select(retiredNumber => retiredNumber.Id)
                         .ToArray();

    public static int[] ActiveIds(this List<PersonSingleSeasonRecordEditModel> singleSeasonRecords)
        => singleSeasonRecords.Where(singleSeasonRecord => !singleSeasonRecord.IsDeleted)
                              .Select(singleSeasonRecord => singleSeasonRecord.Id)
                              .ToArray();

    public static int[] ActiveIds(this List<TeamEditModel> teams)
        => teams.Where(team => !team.IsDeleted)
                .Select(team => team.Id)
                .ToArray();

    public static Constant.Sport[] ToConstantArray(this List<Entity.PersonSport> personSports)
        => personSports.Select(sport => Constant.Sport.Find(sport.SportId))
                       .ToArray();

    public static PersonEditModel ToEditModel(this Entity.Person person)
        => new(new PersonModel(person));

    public static PersonNicknameEditModel ToEditModel(this Entity.PersonNickname personNickname)
        => new(new PersonNicknameModel(personNickname));

    public static PersonTeamEditModel ToEditModel(this Entity.PersonTeam personTeam)
        => new(new PersonTeamModel(personTeam));

    public static ProjectPersonEditModel ToEditModel(this Entity.ProjectPerson projectPerson)
        => new(new ProjectPersonModel(projectPerson));

    public static TeamEditModel ToEditModel(this Entity.Team team)
        => new(new TeamModel(team));

    public static List<PersonAccomplishmentEditModel> ToEditModelList(this List<Entity.PersonAccomplishment> personAccomplishments)
        => personAccomplishments.Select(personAccomplishment => new PersonAccomplishmentEditModel(personAccomplishment))
                                .ToList();

    public static List<PersonAllStarEditModel> ToEditModelList(this List<Entity.AllStar> allStars)
       => allStars.Select(allStar => new PersonAllStarEditModel(allStar))
                  .ToList();

    public static List<PersonAwardEditModel> ToEditModelList(this List<Entity.PersonAward> personAwards)
        => personAwards.Select(personAward => new PersonAwardEditModel(personAward))
                       .ToList();

    public static List<PersonCareerRecordEditModel> ToEditModelList(this List<Entity.CareerRecord> careerRecords)
        => careerRecords.Select(careerRecord => new PersonCareerRecordEditModel(careerRecord))
                        .ToList();

    public static List<PersonCollegeHallOfFameEditModel> ToEditModelList(this List<Entity.CollegeHallOfFame> collegeHallOfFames)
        => collegeHallOfFames.Select(collegeHallOfFame => new PersonCollegeHallOfFameEditModel(collegeHallOfFame))
                             .ToList();

    public static List<PersonCollegeRetiredNumberEditModel> ToEditModelList(this List<Entity.CollegeRetiredNumber> collegeRetiredNumbers)
        => collegeRetiredNumbers.Select(collegeRetiredNumber => new PersonCollegeRetiredNumberEditModel(collegeRetiredNumber))
                                .ToList();

    public static List<PersonFranchiseHallOfFameEditModel> ToEditModelList(this List<Entity.FranchiseHallOfFame> franchiseHallOfFames)
        => franchiseHallOfFames.Select(franchiseHallOfFame => new PersonFranchiseHallOfFameEditModel(franchiseHallOfFame))
                               .ToList();

    public static List<PersonHallOfFameEditModel> ToEditModelList(this List<Entity.HallOfFame> hallOfFames)
        => hallOfFames.Select(hallOfFame => new PersonHallOfFameEditModel(hallOfFame))
                      .ToList();

    public static List<PersonInternationalHallOfFameEditModel> ToEditModelList(this List<Entity.InternationalHallOfFame> internationalHallOfFames)
        => internationalHallOfFames.Select(internationalHallOfFame => new PersonInternationalHallOfFameEditModel(internationalHallOfFame))
                                   .ToList();

    public static List<PersonLeaderEditModel> ToEditModelList(this List<Entity.Leader> leaders)
        => leaders.Select(leader => new PersonLeaderEditModel(leader))
                  .ToList();

    public static List<PersonCollegeEditModel> ToEditModelList(this IEnumerable<Entity.PersonCollege> colleges)
        => colleges.Select(college => new PersonCollegeEditModel(college))
                   .ToList();

    public static List<PersonDraftEditModel> ToEditModelList(this IEnumerable<Entity.Draft> drafts)
        => drafts.Select(draft => new PersonDraftEditModel(draft))
                 .ToList();

    public static List<PersonNicknameEditModel> ToEditModelList(this IEnumerable<Entity.PersonNickname> personNicknames)
        => personNicknames.Select(personNickname => personNickname.ToEditModel())
                          .ToList();

    public static List<PersonOccupationEditModel> ToEditModelList(this List<Entity.PersonOccupation> personOccupations)
        => personOccupations.Select(personOccupation => new PersonOccupationEditModel(personOccupation))
                            .ToList();

    public static List<PersonPositionEditModel> ToEditModelList(this List<Entity.PersonPosition> personPositions)
        => personPositions.Select(personPosition => new PersonPositionEditModel(personPosition))
                          .ToList();

    public static List<PersonRetiredNumberEditModel> ToEditModelList(this List<Entity.RetiredNumber> retiredNumbers)
        => retiredNumbers.Select(retiredNumber => new PersonRetiredNumberEditModel(retiredNumber))
                         .ToList();

    public static List<PersonSingleSeasonRecordEditModel> ToEditModelList(this List<Entity.SingleSeasonRecord> singleSeasonRecords)
        => singleSeasonRecords.Select(singleSeasonRecord => new PersonSingleSeasonRecordEditModel(singleSeasonRecord))
                              .ToList();

    public static List<PersonSportEditModel> ToEditModelList(this List<Entity.PersonSport> personSports)
        => personSports.Select(personSport => new PersonSportEditModel(personSport))
                       .ToList();

    public static List<PersonTeamEditModel> ToEditModelList(this IEnumerable<Entity.PersonTeam> personTeams)
        => personTeams.Select(personTeam => personTeam.ToEditModel())
                      .ToList();
}
