namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class HallOfFameProfileModel(Entity.HallOfFame hallOfFame)
{
    public int? BallotNumber 
        => hallOfFame.BallotNumber;

    public string BallotNumberName 
        => Constant.BallotNumber.Find(BallotNumber ?? 0)?.Name;

    public int? InductionYear 
        => hallOfFame.InductionYear;

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.Find(hallOfFame.SportLeagueLevelId);

    public decimal? VotePercentage 
        => hallOfFame.VotePercentage;
}
