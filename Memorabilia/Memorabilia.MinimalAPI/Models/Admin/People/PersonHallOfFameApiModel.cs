namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonHallOfFameApiModel
{
    private readonly Entity.HallOfFame _hallOfFame;
    private readonly Constant.SportLeagueLevel _sportLeagueLevel;

    public PersonHallOfFameApiModel(Entity.HallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
        _sportLeagueLevel = Constant.SportLeagueLevel.Find(_hallOfFame.SportLeagueLevelId);
    }

    public int? BallotNumber
        => _hallOfFame.BallotNumber;

    public int? InductionYear
        => _hallOfFame.InductionYear;

    public string Sport
        => _sportLeagueLevel.Sport.Name;

    public string SportLeageLevel
        => _sportLeagueLevel.Name;

    public decimal? VotePercentage
        => _hallOfFame.VotePercentage;
}
