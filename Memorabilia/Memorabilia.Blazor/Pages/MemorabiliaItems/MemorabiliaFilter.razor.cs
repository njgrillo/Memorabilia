namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaFilter
{
    [Parameter]
    public string AdditionalStyle { get; set; }

    [Parameter]
    public bool DisplayAcquisitionType { get; set; }
        = true;

    [Parameter]
    public int[] InitialAcquistionTypeIds { get; set; }
        = [];

    [Parameter]
    public EventCallback<MemorabiliaSearchCriteria> OnFilter { get; set; }    

    protected bool HasInitialFilters
        => InitialAcquistionTypeIds.Length > 0;

    protected MemorabiliaSearchCriteria Model { get; set; } 
        = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || !HasInitialFilters)
            return;

        await FilterItems();
    }

    protected override void OnParametersSet()
    {
        if (InitialAcquistionTypeIds.Length != 0)
        {
            Model.AcquisitionTypeIds = InitialAcquistionTypeIds;
        }            
    }

    protected async Task FilterItems()
    {
        await OnFilter.InvokeAsync(Model);
    }

    protected async Task ResetCriteria()
    {
        Model = new();

        await FilterItems();
    }
}
