#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class EditPage<TItem> : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public RenderFragment AdditionalButtons { get; set; }

    [Parameter]
    public string BackNavigationPath { get; set; }

    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public string ContinueNavigationPath { get; set; }

    [Parameter]
    public bool DisplayFooter { get; set; } = true;

    [Parameter]
    public bool DisplaySaveContinueButton { get; set; } = true;

    [Parameter]
    public EditModeType EditMode { get; set; }

    [Parameter]
    public string ExitNavigationPath { get; set; }

    [Parameter]
    public string ImagePath { get; set; }

    [Parameter]
    public string ItemName { get; set; }

    [Parameter]
    public TItem Model { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }

    [Parameter]
    public string PageFooterButtonText { get; set; } = "Back";

    [Parameter]
    public string PageFooterNavigationPath { get; set; }

    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public RenderFragment TimelineContent { get; set; }

    [Parameter]
    public bool UseMultipleButtons { get; set; }

    private bool _continue;

    protected async Task HandleValidSubmit()
    {
        await OnSave.InvokeAsync(Model).ConfigureAwait(false);

        var url = _continue ? ContinueNavigationPath : ExitNavigationPath;

        NavigationManager.NavigateTo(url);
        Snackbar.Add($"{ItemName} {(ItemName.EndsWith("s") ? "were " : "was ")} {(EditMode == EditModeType.Add ? "added" : "updated")} successfully!", Severity.Success);
    }

    protected async Task Load()
    {
        await OnLoad.InvokeAsync().ConfigureAwait(false);
    }
}
