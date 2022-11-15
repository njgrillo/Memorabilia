namespace Memorabilia.Blazor.Controls.DropDowns;

public class BaseballTypeDropDown : GameStyleDropDown<BaseballType>
{
    protected override void LoadItems()
    {
        Items = GameStyleType != null ? BaseballType.GetAll(GameStyleType) : BaseballType.All;
    }
}
