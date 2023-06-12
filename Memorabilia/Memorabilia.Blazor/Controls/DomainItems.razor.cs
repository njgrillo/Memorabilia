namespace Memorabilia.Blazor.Controls;

public partial class DomainItems
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
    public EventCallback<DomainEditModel> OnDelete { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    protected DomainsModel ViewModel;

    protected async Task Delete(DomainEditModel viewModel)
    {
        await OnDelete.InvokeAsync(viewModel);
    }

    protected async Task Load()
    {
        await OnLoad.InvokeAsync();
    }
}
