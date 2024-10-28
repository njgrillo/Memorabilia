namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames;

public class SportHallOfFameViewModel
{
    private readonly Entity.HallOfFame _hallOfFame;

    public SportHallOfFameViewModel() { }

    public SportHallOfFameViewModel(Entity.HallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public int? BallotNumber
        => _hallOfFame.BallotNumber;

    public int Id
        => _hallOfFame.Id;

    public int? InductionYear
        => _hallOfFame.InductionYear;

    public int PersonId
        => _hallOfFame.PersonId;

    public int SportLeagueLevelId
        => _hallOfFame.SportLeagueLevelId;

    public string SportLeagueLevelName
        => Constant.SportLeagueLevel.Find(_hallOfFame.SportLeagueLevelId)?.Name;

    public decimal? VotePercentage
        => _hallOfFame.VotePercentage;
}
