
namespace Memorabilia.Blazor.Controls.DropDowns;

public class BasketballTypeDropDown : DropDown<BasketballType, int>
{
    protected override void OnInitialized()
    {
        Items = BasketballType.All;
        Label = "Type";
    }
}
