using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.HallOfFames;

public class HallOfFamesViewModel
{
    public HallOfFamesViewModel() { }

    public HallOfFamesViewModel(IEnumerable<HallOfFame> hallOfFames)
    {
        HallOfFames = hallOfFames.Select(hallOfFame => new HallOfFameViewModel(hallOfFame))
                                 .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                 .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<HallOfFameViewModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameViewModel>();

    public int InductionYear { get; set; }

    public string ResultsTitle => $"{(InductionYear > 0 ? InductionYear : string.Empty)} Hall of Famers";

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
