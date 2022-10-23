#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class ToggleCheckBox
{
    [Parameter]
    public string AssociateToText { get; set; }

    [Parameter]
    public bool CheckOnInitialize { get; set; }

    [Parameter]
    public bool IsChecked { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    protected string ItemTypeNameLabel => $"Associate {ItemType?.Name} with {AssociateToText}";

    protected override void OnInitialized()
    {
        IsChecked = CheckOnInitialize;
    }

    private void CheckboxClicked(bool isChecked)
    {
        IsChecked = isChecked;
    }
}
