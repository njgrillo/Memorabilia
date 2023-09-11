namespace Memorabilia.Blazor.Controls;

public partial class PageEditor<TItem> where TItem : EditModel
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public RenderFragment AdditionalButtons { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string ContinueNavigationPath { get; set; }

    [Parameter]
    public bool DisplayBackToMenuItemLink { get; set; }

    [Parameter]
    public bool DisplayFooter { get; set; }
        = true;

    [Parameter]
    public bool DisplaySaveContinueButton { get; set; }
        = true;

    [Parameter]
    public bool DisplaySaveExitButton { get; set; }
        = true;

    [Parameter]
    public TItem EditModel { get; set; }

    [Parameter]
    public string ExitNavigationPath { get; set; }

    [Parameter]
    public RenderFragment ImagePreview { get; set; }

    [Parameter]
    public string MenuItemLinkText { get; set; }

    [Parameter]
    public string MenuItemPath { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public string PageImageFileName { get; set; }

    [Parameter]
    public RenderFragment TimelineContent { get; set; }

    [Parameter]
    public bool UseMultipleButtons { get; set; }
        = true;

    public Alert[] ValidationResultAlerts
        => EditModel.ValidationResult != null
            ? EditModel.ValidationResult.Errors
                                        .Select(error => new Alert(error.ErrorMessage, Severity.Error))
                                        .ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult != null && !EditModel.ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected async Task Save(bool exit)
    {
        EditModeType editModeType = EditModel.Id > 0
            ? EditModeType.Update
            : EditModeType.Add;

        await OnSave.InvokeAsync();        

        if (!EditModel.ValidationResult.IsValid)
        {
            Snackbar.Add($"{EditModel.ItemTitle} {(EditModel.ItemTitle.EndsWith("s") ? "were not " : "was not")} {editModeType.ToEditModeTypeNamePastTense()}", Severity.Error);
            return;
        }

        NavigationManager.NavigateTo(!exit
            ? ContinueNavigationPath
            : ExitNavigationPath);

        Snackbar.Add($"{EditModel.ItemTitle} {(EditModel.ItemTitle.EndsWith("s") ? "were " : "was ")} {editModeType.ToEditModeTypeNamePastTense()} successfully!", Severity.Success);
    }
}
