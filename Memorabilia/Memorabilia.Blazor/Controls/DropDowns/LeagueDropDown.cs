#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeagueDropDown : DropDown<League, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = SportLeagueLevel != null ? League.GetAll(SportLeagueLevel) : League.All;
        Label = "League";
    }
}
