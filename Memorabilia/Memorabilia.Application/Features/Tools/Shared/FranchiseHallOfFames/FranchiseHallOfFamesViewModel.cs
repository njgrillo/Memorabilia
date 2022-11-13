using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFamesViewModel
{
    public FranchiseHallOfFamesViewModel() { }

    public FranchiseHallOfFamesViewModel(IEnumerable<FranchiseHallOfFame> franchiseHallOfFames, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        FranchiseHallOfFames = franchiseHallOfFames.Select(hallOfFame => new FranchiseHallOfFameViewModel(hallOfFame, sportLeagueLevel))
                                                   .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                                   .ThenBy(hallOfFame => hallOfFame.PersonName);
    }    

    public IEnumerable<FranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameViewModel>();

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string ResultsTitle => $"{FranchiseName} Hall of Famers";
}
