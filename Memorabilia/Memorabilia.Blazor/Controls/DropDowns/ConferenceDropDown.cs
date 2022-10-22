#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ConferenceDropDown : DropDown<Conference, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = SportLeagueLevel != null ? Conference.GetAll(SportLeagueLevel) : Conference.All;
        Label = "Conference";
    }
}
