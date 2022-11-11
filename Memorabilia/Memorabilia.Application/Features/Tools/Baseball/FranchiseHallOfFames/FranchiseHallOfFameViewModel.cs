using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.FranchiseHallOfFames;

public class FranchiseHallOfFameViewModel
{
    private readonly FranchiseHallOfFame _franchiseHallOfFame;

    public FranchiseHallOfFameViewModel(FranchiseHallOfFame franchiseHallOfFame)
    {
        _franchiseHallOfFame = franchiseHallOfFame;
    }

    public string FranchiseName => _franchiseHallOfFame.Franchise.FullName;

    public string InductionYear => _franchiseHallOfFame.Year.ToString();

    public int PersonId => _franchiseHallOfFame.PersonId;

    public string PersonImageFileName => _franchiseHallOfFame.Person.ImageFileName;

    public string PersonName => _franchiseHallOfFame.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";
}
