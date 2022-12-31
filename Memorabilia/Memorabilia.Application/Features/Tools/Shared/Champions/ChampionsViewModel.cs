﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public class ChampionsViewModel
{
    public ChampionsViewModel() { }

    public ChampionsViewModel(IEnumerable<Champion> champions, Domain.Constants.Sport sport)
    {
        Champions = champions.Select(champion => new ChampionViewModel(champion, sport));
    }

    public IEnumerable<ChampionViewModel> Champions { get; set; } = Enumerable.Empty<ChampionViewModel>();
}
