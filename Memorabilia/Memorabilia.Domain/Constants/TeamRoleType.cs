namespace Memorabilia.Domain.Constants;

public sealed class TeamRoleType : DomainItemConstant
{
    public static readonly TeamRoleType Coach = new(1, "Coach");
    public static readonly TeamRoleType DefensiveCoordinator = new(2, "Defensive Coordinator", "DC");
    public static readonly TeamRoleType DefensiveLineCoach = new(3, "Defensive Line Coach", "D-Line Coach");
    public static readonly TeamRoleType Executive = new(4, "Executive", "Exec");
    public static readonly TeamRoleType GeneralManager = new(5, "General Manager", "GM");
    public static readonly TeamRoleType HeadCoach = new(6, "Head Coach");
    public static readonly TeamRoleType LinebackerCoach = new(7, "Linebacker Coach");
    public static readonly TeamRoleType Manager = new(8, "Manager", "M");
    public static readonly TeamRoleType OffensiveCoordinator = new(9, "Offensive Coordinator", "OC");
    public static readonly TeamRoleType OffensiveLineCoach = new(10, "Offensive Line Coach", "O-Line Coach");
    public static readonly TeamRoleType Owner = new(11, "Owner");
    public static readonly TeamRoleType Player = new(12, "Player");
    public static readonly TeamRoleType QuarterbackCoach = new(13, "Quarterback Coach");
    public static readonly TeamRoleType RunningBackCoach = new(14, "Running Back Coach");
    public static readonly TeamRoleType SecondaryCoach = new(15, "Secondary Coach");
    public static readonly TeamRoleType SpecialTeamsCoach = new(16, "Special Teams Coach");
    public static readonly TeamRoleType TightEndCoach = new(17, "Tight End Coach");

    public static readonly TeamRoleType[] All =
    {
        Coach,
        DefensiveCoordinator,
        DefensiveLineCoach,
        Executive,
        GeneralManager,
        HeadCoach,
        LinebackerCoach,
        Manager,
        OffensiveCoordinator,
        OffensiveLineCoach,
        Owner,
        Player,
        QuarterbackCoach,
        RunningBackCoach,
        SecondaryCoach,
        SpecialTeamsCoach,
        TightEndCoach
    };

    public static readonly TeamRoleType[] BaseballRoleTypes =
    {
        Coach,
        Executive,
        GeneralManager,
        Manager,
        Owner,
        Player
    };

    public static readonly TeamRoleType[] FootballRoleTypes =
    {
        DefensiveCoordinator,
        DefensiveLineCoach,
        Executive,
        HeadCoach,
        LinebackerCoach,
        OffensiveCoordinator,
        OffensiveLineCoach,
        Owner,
        Player,
        QuarterbackCoach,
        RunningBackCoach,
        SecondaryCoach,
        SpecialTeamsCoach,
        TightEndCoach
    };

    private TeamRoleType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static TeamRoleType Find(int id)
    {
        return All.SingleOrDefault(teamRoleType => teamRoleType.Id == id);
    }

    public static TeamRoleType[] Get(SportLeagueLevel sportLeagueLevel)
    {
        if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
            return BaseballRoleTypes;

        if (sportLeagueLevel == SportLeagueLevel.NationalFootballLeague)
            return FootballRoleTypes;

        return All;
    }
}
