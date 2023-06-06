namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class HallOfFameProfileModel
{
    private readonly Entity.HallOfFame _hallOfFame;

    public HallOfFameProfileModel(Entity.HallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public int? BallotNumber 
        => _hallOfFame.BallotNumber;

    public string BallotNumberName 
        => Constant.BallotNumber.Find(BallotNumber ?? 0)?.Name;

    public int? InductionYear 
        => _hallOfFame.InductionYear;

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.Find(_hallOfFame.SportLeagueLevelId);

    public decimal? VotePercentage 
        => _hallOfFame.VotePercentage;
}
