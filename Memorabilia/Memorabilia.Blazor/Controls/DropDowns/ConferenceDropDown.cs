

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ConferenceDropDown : DropDown<Conference, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevel != null ? Conference.GetAll(SportLeagueLevel) : Conference.All;
        Label = "Conference";
    }
}
