using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public class HallOfFamesViewModel
{
    public HallOfFamesViewModel() { }

    public HallOfFamesViewModel(IEnumerable<HallOfFame> hallOfFames, Domain.Constants.Sport sport)
    {
        HallOfFames = hallOfFames.Select(hallOfFame => new HallOfFameViewModel(hallOfFame, sport))
                                 .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                 .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<HallOfFameViewModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameViewModel>();

    public int InductionYear { get; set; }

    public string ResultsTitle => $"{(InductionYear > 0 ? InductionYear : string.Empty)} Hall of Famers";
}
