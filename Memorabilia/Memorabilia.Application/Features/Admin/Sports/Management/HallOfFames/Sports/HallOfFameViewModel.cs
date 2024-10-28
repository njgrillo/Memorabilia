namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

public class HallOfFameViewModel
{
    private readonly Entity.HallOfFame _hallOfFame;

    public HallOfFameViewModel() { }

    public HallOfFameViewModel(Entity.HallOfFame hallOfFame)
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
