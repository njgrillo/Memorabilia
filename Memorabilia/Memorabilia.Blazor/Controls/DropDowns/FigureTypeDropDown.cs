namespace Memorabilia.Blazor.Controls.DropDowns;

public class FigureTypeDropDown : DropDown<FigureType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = FigureType.All;
        Label = "Type";
    }
}
