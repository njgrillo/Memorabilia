namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeaderTypeDropDown : DropDown<LeaderType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = LeaderType.All;
        Label = "Leader Type";
    }
}
