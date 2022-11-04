using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.HallOfFames;

public class HallOfFameViewModel
{
    private readonly HallOfFame _hallOfFame;

    public HallOfFameViewModel(HallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public string BallotNumber => _hallOfFame.BallotNumber.HasValue ? _hallOfFame.BallotNumber.ToString() : string.Empty;

    public string InductionYear => _hallOfFame.InductionYear.ToString();

    public int PersonId => _hallOfFame.PersonId;

    public string PersonImagePath => _hallOfFame.Person.ImagePath;

    public string PersonName => _hallOfFame.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string VotePercentage => _hallOfFame.VotePercentage.HasValue ? _hallOfFame.VotePercentage.ToString() : string.Empty;
}
