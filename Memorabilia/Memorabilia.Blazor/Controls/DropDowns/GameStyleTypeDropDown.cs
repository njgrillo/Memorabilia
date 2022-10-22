namespace Memorabilia.Blazor.Controls.DropDowns;

public class GameStyleTypeDropDown : DropDown<GameStyleType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = GameStyleType.All;
        Label = "Game Style Type";
    }
}
