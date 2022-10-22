
namespace Memorabilia.Blazor.Controls.DropDowns;

public class BasketballTypeDropDown : DropDown<BasketballType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = BasketballType.All;
        Label = "Type";
    }
}
