using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFamesModel
{
    public FranchiseHallOfFamesModel() { }

    public FranchiseHallOfFamesModel(IEnumerable<FranchiseHallOfFame> franchiseHallOfFames, Constant.Sport sport)
    {
        FranchiseHallOfFames = franchiseHallOfFames.Select(hallOfFame => new FranchiseHallOfFameModel(hallOfFame, sport))
                                                   .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                                   .ThenBy(hallOfFame => hallOfFame.PersonName);
    }
    
    public Constant.Franchise Franchise { get; set; }

    public IEnumerable<FranchiseHallOfFameModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameModel>();

    public string FranchiseName => Franchise?.Name;

    public string ResultsTitle => $"{FranchiseName} Hall of Famers";
}
