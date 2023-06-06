using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public class HallOfFameModel : PersonSportToolModel
{
    private readonly HallOfFame _hallOfFame;

    public HallOfFameModel(HallOfFame hallOfFame, Constant.Sport sport)
    {
        _hallOfFame = hallOfFame;
        Sport = sport;
    }

    public string BallotNumber => _hallOfFame.BallotNumber.HasValue ? _hallOfFame.BallotNumber.ToString() : string.Empty;

    public string InductionYear => _hallOfFame.InductionYear.ToString();

    public override int PersonId => _hallOfFame.PersonId;

    public override string PersonImageFileName => _hallOfFame.Person?.ImageFileName;

    public override string PersonName => _hallOfFame.Person?.DisplayName;

    public string VotePercentage => _hallOfFame.VotePercentage.HasValue ? _hallOfFame.VotePercentage.ToString() : string.Empty;
}
