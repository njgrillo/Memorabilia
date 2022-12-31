﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public class ChampionViewModel : TeamSportToolViewModel
{
    private readonly Champion _champion;

    public ChampionViewModel(Champion champion, Domain.Constants.Sport sport)
    {
        _champion = champion;
        Sport = sport;
    }

    public string Franchise => _champion.Team.Franchise.FullName;

    public override int TeamId => _champion.TeamId;

    public override string TeamName => _champion.Team.ToString();

    public string Year => _champion.Year.ToString();
}
