namespace Memorabilia.Blazor.Controls.DropDowns;

public class LevelTypeDropDown : DropDown<LevelType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = LevelType.All;
        Label = "Level Type";
    }
}
