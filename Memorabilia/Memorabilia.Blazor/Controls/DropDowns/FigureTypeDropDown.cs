namespace Memorabilia.Blazor.Controls.DropDowns;

public class FigureTypeDropDown : DropDown<FigureType, int>
{
    protected override void OnInitialized()
    {
        Items = FigureType.All;
        Label = "Type";
    }
}
