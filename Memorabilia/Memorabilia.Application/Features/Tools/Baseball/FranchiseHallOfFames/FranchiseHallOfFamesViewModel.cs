using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.FranchiseHallOfFames;

public class FranchiseHallOfFamesViewModel
{
    public FranchiseHallOfFamesViewModel() { }

    public FranchiseHallOfFamesViewModel(IEnumerable<FranchiseHallOfFame> franchiseHallOfFames)
    {
        FranchiseHallOfFames = franchiseHallOfFames.Select(hallOfFame => new FranchiseHallOfFameViewModel(hallOfFame))
                                                   .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                                   .ThenBy(hallOfFame => hallOfFame.PersonName);
    }    

    public IEnumerable<FranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameViewModel>();

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string ResultsTitle => $"{FranchiseName} Hall of Famers";

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
