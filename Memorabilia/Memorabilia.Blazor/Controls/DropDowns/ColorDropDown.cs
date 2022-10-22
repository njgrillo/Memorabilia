#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ColorDropDown : DropDown<Domain.Constants.Color, int>
{
    [Parameter]
    public ItemType ItemType { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = Domain.Constants.Color.GetAll(ItemType);
        Label = "Color";
    }
}
