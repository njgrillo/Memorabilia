using DashboardItemModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemModel;

namespace Memorabilia.Application.Extensions;

public static class DomainExtensions
{
    public static int[] ActiveIds<T>(this List<T> items) where T : EditModel
       => items.Where(item => !item.IsDeleted)
               .Select(item => item.Id)
               .ToArray() ?? Array.Empty<int>();

    public static int[] DeletedIds<T>(this List<T> items) where T : EditModel
        => items.Where(item => item.IsDeleted)
                .Select(item => item.Id)
                .ToArray() ?? Array.Empty<int>(); 

    public static Constant.Sport[] ToConstantArray(this List<Entity.PersonSport> personSports)
        => personSports.Select(sport => Constant.Sport.Find(sport.SportId))
                       .ToArray();    

    public static SpotEditModel ToEditModel(this Entity.Autograph autograph)
        => new(new SpotModel(autograph));

    public static CommissionerEditModel ToEditModel(this Entity.Commissioner commissioner)
        => new(new CommissionerModel(commissioner));

    public static ConferenceEditModel ToEditModel(this Entity.Conference conference)
        => new(new ConferenceModel(conference));

    public static DashboardItemEditModel ToEditModel(this Entity.DashboardItem dashboardItem)
        => new(new DashboardItemModel(dashboardItem));

    public static DivisionEditModel ToEditModel(this Entity.Division division)
        => new(new DivisionModel(division));

    public static FranchiseEditModel ToEditModel(this Entity.Franchise franchise)
        => new(new FranchiseModel(franchise));

    public static ItemTypeBrandEditModel ToEditModel(this Entity.ItemTypeBrand itemTypeBrand)
        => new(new ItemTypeBrandModel(itemTypeBrand));

    public static ItemTypeGameStyleEditModel ToEditModel(this Entity.ItemTypeGameStyleType itemTypeGameStyle)
        => new(new ItemTypeGameStyleModel(itemTypeGameStyle));

    public static ItemTypeLevelEditModel ToEditModel(this Entity.ItemTypeLevel itemTypeLevel)
        => new(new ItemTypeLevelModel(itemTypeLevel));

    public static ItemTypeSizeEditModel ToEditModel(this Entity.ItemTypeSize itemTypeSize)
        => new(new ItemTypeSizeModel(itemTypeSize));

    public static ItemTypeSportEditModel ToEditModel(this Entity.ItemTypeSport itemTypeSport)
        => new(new ItemTypeSportModel(itemTypeSport));

    public static ItemTypeSpotEditModel ToEditModel(this Entity.ItemTypeSpot itemTypeSpot)
        => new(new ItemTypeSpotModel(itemTypeSpot));

    public static LeaguePresidentEditModel ToEditModel(this Entity.LeaguePresident leaguePresident)
        => new(new LeaguePresidentModel(leaguePresident));

    public static LeagueEditModel ToEditModel(this Entity.League league)
        => new(new LeagueModel(league));

    public static MemorabiliaEditModel ToEditModel(this Entity.Memorabilia memorabilia)
        => new(new MemorabiliaModel(memorabilia));

    public static PersonEditModel ToEditModel(this Entity.Person person)
        => new(new PersonModel(person));

    public static PersonNicknameEditModel ToEditModel(this Entity.PersonNickname personNickname)
        => new(new PersonNicknameModel(personNickname));

    public static PersonTeamEditModel ToEditModel(this Entity.PersonTeam personTeam)
        => new(new PersonTeamModel(personTeam));

    public static PewterEditModel ToEditModel(this Entity.Pewter pewter)
        => new(new PewterModel(pewter));

    public static PositionEditModel ToEditModel(this Entity.Position position)
        => new(new PositionModel(position));

    public static ProjectEditModel ToEditModel(this Entity.Project project)
        => new(new ProjectModel(project));

    public static ProjectPersonEditModel ToEditModel(this Entity.ProjectPerson projectPerson)
        => new(new ProjectPersonModel(projectPerson));

    public static SportLeagueLevelEditModel ToEditModel(this Entity.SportLeagueLevel sportLeagueLevel)
        => new(new SportLeagueLevelModel(sportLeagueLevel));

    public static SportEditModel ToEditModel(this Entity.Sport sport)
        => new(new SportModel(sport));

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

    public static List<TeamChampionshipEditModel> ToEditModelList(this Entity.Champion[] champions)
        => champions.Select(teamChampionship => new TeamChampionshipEditModel(new TeamChampionshipModel(teamChampionship)))
                    .ToList();

    public static List<TeamConferenceEditModel> ToEditModelList(this Entity.TeamConference[] conferences)
        => conferences.Select(conference => new TeamConferenceEditModel(new TeamConferenceModel(conference)))
                      .ToList();

    public static List<TeamDivisionEditModel> ToEditModelList(this Entity.TeamDivision[] divisions)
        => divisions.Select(division => new TeamDivisionEditModel(new TeamDivisionModel(division)))
                    .ToList();

    public static List<TeamLeagueEditModel> ToEditModelList(this Entity.TeamLeague[] leagues)
        => leagues.Select(league => new TeamLeagueEditModel(new TeamLeagueModel(league)))
                  .ToList();

    public static string ToEditModeTypeName(this int id)
        => id > 0
            ? Constant.EditModeType.Update.Name
            : Constant.EditModeType.Add.Name;

    public static string ToEditModeTypeName(this Constant.EditModeType editModeType)
        => editModeType == Constant.EditModeType.Update
            ? Constant.EditModeType.Update.Name
            : Constant.EditModeType.Add.Name;

    public static string ToEditModeTypeNamePastTense(this Constant.EditModeType editModeType)
        => editModeType == Constant.EditModeType.Update
            ? "updated"
            : "added";

    public static PersonImageEditModel ToImageEditModel(this Entity.Person person)
        => new(new PersonImageModel(person));

    public static PersonTeamsEditModel ToTeamEditModel(this Entity.Person person)
        => new(new PersonTeamsModel(person));
}
