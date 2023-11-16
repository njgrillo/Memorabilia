﻿namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class PositionsProfile : SportProfile
{
    private Entity.PersonPosition[] Positions
        = [];

    protected override void OnParametersSet()
    {
        Positions = Person.Positions
                          .Filter(Sport)
                          .OrderBy(position => position.Position.Name) 
                          .ToArray();
    }
}
