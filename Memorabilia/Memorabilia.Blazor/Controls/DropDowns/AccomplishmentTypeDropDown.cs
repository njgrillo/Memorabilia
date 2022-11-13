#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class AccomplishmentTypeDropDown : DropDown<AccomplishmentType, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevel != null
            ? AccomplishmentType.GetAll(SportLeagueLevel) 
            : AccomplishmentType.All;
        Label = "Accomplishment";
    }
}
