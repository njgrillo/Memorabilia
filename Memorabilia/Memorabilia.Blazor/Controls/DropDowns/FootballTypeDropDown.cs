namespace Memorabilia.Blazor.Controls.DropDowns;

public class FootballTypeDropDown : DropDown<FootballType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = FootballType.All;
        Label = "Type";
    }
}
