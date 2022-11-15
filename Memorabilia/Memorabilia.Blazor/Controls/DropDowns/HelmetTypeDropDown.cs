namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetTypeDropDown : GameStyleDropDown<HelmetType>
{
    protected override void LoadItems()
    {
        Items = GameStyleType != null ? HelmetType.GetAll(GameStyleType) : HelmetType.All;
    }
}
