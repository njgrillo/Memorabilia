namespace Memorabilia.Blazor.Controls.DropDowns;

public class BrandDropDown : DropDown<Brand, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Brand.All;
        Label = "Brand";
    }
}
