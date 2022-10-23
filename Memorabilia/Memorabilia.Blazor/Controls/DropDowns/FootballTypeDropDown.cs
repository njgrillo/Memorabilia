namespace Memorabilia.Blazor.Controls.DropDowns;

public class FootballTypeDropDown : DropDown<FootballType, int>
{
    protected override void OnInitialized()
    {
        Items = FootballType.All;
        Label = "Type";
    }
}
