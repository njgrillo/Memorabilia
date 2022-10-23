namespace Memorabilia.Blazor.Controls.DropDowns;

public class ChampionshipTypeDropDown : DropDown<ChampionType, int>
{
    protected override void OnInitialized()
    {
        Items = ChampionType.All;
        Label = "Championship Type";
    }
}
