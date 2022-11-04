namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeaderTypeDropDown : DropDown<LeaderType, int>
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevelId > 0 ? LeaderType.GetAll(SportLeagueLevelId) : LeaderType.All;
        Label = "Leader Type";
    }
}
