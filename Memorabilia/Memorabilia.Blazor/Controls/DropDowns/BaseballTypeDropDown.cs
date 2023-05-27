namespace Memorabilia.Blazor.Controls.DropDowns;

public class BaseballTypeDropDown : GameStyleDropDown<BaseballType>
{
    [Parameter]
    public bool UseProjectTypes { get; set; }

    protected override void LoadItems()
    {
        Items = UseProjectTypes
            ? BaseballType.ProjectTypes
            : GameStyleType != null 
                ? BaseballType.GetAll(GameStyleType) 
                : BaseballType.All;
    }
}
