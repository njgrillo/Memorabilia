namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class ItemTypeSelector
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public int ItemTypeId { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public bool MultiSignedItem { get; set; }    

    protected ItemType SelectedItemType { get; set; }

    protected override void OnInitialized()
    {
        SelectedItemType = ItemType.Find(ItemTypeId);
    }

    protected async Task ItemTypeChanged(ItemType itemType)
    {
        SelectedItemType = itemType;

        await OnParameterChanged();
    }

    protected async Task MultiSignedItemChanged(bool isMultiSignedItem)
    {
        MultiSignedItem = isMultiSignedItem;

        await OnParameterChanged();
    }

    private async Task OnParameterChanged()
    {
        var parameters = new Dictionary<string, object>
        {
            { "ItemTypeId", SelectedItemType.Id },
            { "MultiSignedItem", MultiSignedItem }
        };

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
