namespace Memorabilia.Blazor.Controls.DropDowns;

public class BatTypeDropDown : DropDown<BatType, int>
{
    protected override void OnInitialized()
    {
        Items = BatType.All;
        Label = "Bat Type";
    }
}
