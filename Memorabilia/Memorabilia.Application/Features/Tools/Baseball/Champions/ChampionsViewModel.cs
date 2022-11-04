using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Champions;

public class ChampionsViewModel
{
    public ChampionsViewModel() { }

    public ChampionsViewModel(IEnumerable<Champion> champions)
    {
        Champions = champions.Select(champion => new ChampionViewModel(champion));
    }
    public IEnumerable<ChampionViewModel> Champions { get; set; } = Enumerable.Empty<ChampionViewModel>();
}
