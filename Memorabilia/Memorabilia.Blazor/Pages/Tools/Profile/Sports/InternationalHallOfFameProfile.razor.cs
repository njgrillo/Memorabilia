﻿namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class InternationalHallOfFameProfile : SportProfile
{
    private Entity.InternationalHallOfFame[] InternationalHallOfFames
        = [];

    protected override void OnParametersSet()
    {
        InternationalHallOfFames = Person.InternationalHallOfFames
                                         .OrderBy(hof => hof.InternationalHallOfFameType.Name)
                                         .ToArray();
    }
}
