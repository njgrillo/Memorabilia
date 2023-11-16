using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaFilter
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public EventCallback<MemorabiliaSearchCriteria> OnFilter { get; set; }

    protected MemorabiliaSearchCriteria Model { get; set; }
        = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        await FilterItems();
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
