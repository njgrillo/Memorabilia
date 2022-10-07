using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class FranchiseHallOfFameProfileViewModel
{
    private readonly FranchiseHallOfFame _hallOfFame;

    public FranchiseHallOfFameProfileViewModel(FranchiseHallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public string FranchiseHallOfFameName => Domain.Constants.FranchiseHallOfFameType.Find(FranchiseId)?.Name;

    public int FranchiseId => _hallOfFame.FranchiseId;

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string Year => _hallOfFame.Year.HasValue ? _hallOfFame.Year.ToString() : string.Empty;
}
