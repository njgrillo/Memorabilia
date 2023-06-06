

namespace Memorabilia.Blazor.Controls;

public partial class DomainItems : ComponentBase
{
    [Parameter]
    public DomainsModel Items
    {
        get
        {
            return ViewModel;
        }
        set
        {
            ViewModel = value;
        }
    }

    [Parameter]
    public EventCallback<SaveDomainViewModel> OnDelete { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    protected DomainsModel ViewModel;

    protected async Task Delete(SaveDomainViewModel viewModel)
    {
        await OnDelete.InvokeAsync(viewModel);
    }

    protected async Task Load()
    {
        await OnLoad.InvokeAsync();
    }
}
