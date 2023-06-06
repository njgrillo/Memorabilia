using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFameModel : PersonSportToolModel
{
    private readonly FranchiseHallOfFame _franchiseHallOfFame;

    public FranchiseHallOfFameModel(FranchiseHallOfFame franchiseHallOfFame, Constant.Sport sport)
    {
        _franchiseHallOfFame = franchiseHallOfFame;
        Sport = sport;
    }

    public string FranchiseName => _franchiseHallOfFame.Franchise.FullName;

    public string InductionYear => _franchiseHallOfFame.Year.ToString();

    public override int PersonId => _franchiseHallOfFame.PersonId;

    public override string PersonImageFileName => _franchiseHallOfFame.Person.ImageFileName;

    public override string PersonName => _franchiseHallOfFame.Person.DisplayName;
}
