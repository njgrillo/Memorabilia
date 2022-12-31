using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFamesViewModel
{
    public FranchiseHallOfFamesViewModel() { }

    public FranchiseHallOfFamesViewModel(IEnumerable<FranchiseHallOfFame> franchiseHallOfFames, Domain.Constants.Sport sport)
    {
        FranchiseHallOfFames = franchiseHallOfFames.Select(hallOfFame => new FranchiseHallOfFameViewModel(hallOfFame, sport))
                                                   .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                                   .ThenBy(hallOfFame => hallOfFame.PersonName);
    }
    
    public Domain.Constants.Franchise Franchise { get; set; }

    public IEnumerable<FranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameViewModel>();

    public string FranchiseName => Franchise?.Name;

    public string ResultsTitle => $"{FranchiseName} Hall of Famers";
}
