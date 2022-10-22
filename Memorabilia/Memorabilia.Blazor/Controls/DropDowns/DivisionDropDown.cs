#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class DivisionDropDown : DropDown<Division, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = SportLeagueLevel != null ? Division.GetAll(SportLeagueLevel) : Division.All;
        Label = "League";
    }
}
