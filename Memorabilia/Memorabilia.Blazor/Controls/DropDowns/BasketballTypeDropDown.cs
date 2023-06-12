namespace Memorabilia.Blazor.Controls.DropDowns;

public class BasketballTypeDropDown : GameStyleDropDown<BasketballType>
{
    protected override void LoadItems()
    {
        Items = GameStyleType != null 
            ? BasketballType.GetAll(GameStyleType) 
            : BasketballType.All;
    }
}
