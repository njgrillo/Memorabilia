namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaFilter
{
    [Parameter]
    public EventCallback<MemorabiliaSearchCriteria> OnFilter { get; set; }

    protected MemorabiliaSearchCriteria Model { get; set; } 
        = new();

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
