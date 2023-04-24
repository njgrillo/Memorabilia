﻿

namespace Memorabilia.Blazor.Controls.DropDowns;

public class DivisionDropDown : DropDown<Division, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevel != null ? Division.GetAll(SportLeagueLevel) : Division.All;
        Label = "League";
    }
}
