#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class EditDomainItem : ComponentBase
{
    [Parameter]
    public SaveDomainViewModel Item
    {
        get
        {
            return _viewModel;
        }
        set
        {
            _viewModel = value;
        }
    }

    [Parameter]
    public int MaxAbbreviationLength { get; set; } = 10;

    [Parameter]
    public int MaxNameLength { get; set; } = 100;

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback<SaveDomainViewModel> OnSave { get; set; }

    private SaveDomainViewModel _viewModel;

    protected async Task Load()
    {
        if (_viewModel.Id == 0)
            return;

        await OnLoad.InvokeAsync();
    }

    protected async Task Save()
    {
        await OnSave.InvokeAsync(_viewModel);
    }
}
