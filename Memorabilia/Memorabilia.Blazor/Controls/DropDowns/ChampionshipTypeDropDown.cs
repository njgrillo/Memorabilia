namespace Memorabilia.Blazor.Controls.DropDowns;

public class ChampionshipTypeDropDown : DropDown<ChampionType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = ChampionType.All;
        Label = "Championship Type";
    }
}
