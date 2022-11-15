namespace Memorabilia.Blazor.Controls.DropDowns;

public class BatTypeDropDown : GameStyleDropDown<BatType>
{
    protected override void LoadItems()
    {
        Items = BatType.All;
    }
}
