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

    public bool Filter(string search)
    {
        bool isNumeric = int.TryParse(search, out int value);

        return search.IsNullOrEmpty() ||
               (isNumeric && BallotNumber.HasValue && BallotNumber.Value == value) ||
               (isNumeric && InductionYear.HasValue && InductionYear.Value == value) ||
               BallotNumberName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (SportLeagueLevel is not null && SportLeagueLevel.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
