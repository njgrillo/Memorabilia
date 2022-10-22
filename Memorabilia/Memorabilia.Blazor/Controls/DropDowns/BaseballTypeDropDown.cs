namespace Memorabilia.Blazor.Controls.DropDowns;

public class BaseballTypeDropDown : DropDown<BaseballType, int> 
{
    protected override async Task OnInitializedAsync()
    {
        Items = BaseballType.All;
        Label = "Type";
    }
}
