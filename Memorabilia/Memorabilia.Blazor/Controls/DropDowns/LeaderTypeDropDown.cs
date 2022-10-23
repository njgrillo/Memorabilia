namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeaderTypeDropDown : DropDown<LeaderType, int>
{
    protected override void OnInitialized()
    {
        Items = LeaderType.All;
        Label = "Leader Type";
    }
}
