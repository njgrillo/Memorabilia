namespace Memorabilia.Blazor.Controls.DropDowns;

public class FootballTypeDropDown : GameStyleDropDown<FootballType>
{
    protected override void LoadItems()
    {
        Items = GameStyleType != null 
            ? FootballType.GetAll(GameStyleType) 
            : FootballType.All;
    }
}
