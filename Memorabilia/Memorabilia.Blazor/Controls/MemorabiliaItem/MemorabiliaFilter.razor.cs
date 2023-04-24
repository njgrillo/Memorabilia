

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaFilter
{
    [Parameter]
    public EventCallback<MemorabiliaSearchCriteria> OnFilter { get; set; }

    public MemorabiliaSearchCriteria ViewModel { get; set; } = new();

    protected async Task FilterItems()
    {
        await OnFilter.InvokeAsync(ViewModel);
    }

    protected async Task ResetCriteria()
    {
        ViewModel = new();

        await FilterItems();
    }
}
