namespace Memorabilia.Blazor.Controls.DropDowns;

public class BrandDropDown : DropDown<Brand, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
        => selectedValues.Count == 0 || selectedValues.Count > 4
            ? $"{selectedValues.Count} brands selected"
            : string.Join(", ", selectedValues.Select(item => Constant.Brand.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = Brand.All;
        Label = "Brand";
    }
}
