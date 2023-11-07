namespace Memorabilia.Blazor.Pages.Help;

public partial class HelpTreeView
{
    [Inject]
    public HelpItemIconService HelpItemIconService { get; set; }

    [Parameter]
    public EventCallback<HelpItem> OnItemSelected { get; set; }

    protected HelpItem SelectedItem { get; set; }

    public async Task OnClick(HelpItem helpItem)
    {
        if (helpItem.HasChildren)
            return;

        await OnItemSelected.InvokeAsync(helpItem);
    }
}
