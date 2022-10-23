namespace Memorabilia.Blazor.Controls.DropDowns;

public class BaseballTypeDropDown : DropDown<BaseballType, int> 
{
    protected override void OnInitialized()
    {
        Items = BaseballType.All;
        Label = "Type";
    }
}
