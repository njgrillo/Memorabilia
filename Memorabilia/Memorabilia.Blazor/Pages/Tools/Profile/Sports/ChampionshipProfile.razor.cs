﻿namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class ChampionshipProfile : SportProfile
{
    private ChampionshipProfileModel[] Championships 
        = [];

    protected override void OnParametersSet()
    {
        Championships = Person.Teams
                              .Championships(Sport, OccupationType)
                              .Select(championship => new ChampionshipProfileModel(championship))
                              .ToArray();
    }
}
