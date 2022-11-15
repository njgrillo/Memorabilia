namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyTypeDropDown : GameStyleDropDown<JerseyType>
{
    protected override void LoadItems()
    {
        Items = JerseyType.All;
    }
}
