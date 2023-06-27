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
    public bool DisplayBackToMenuItemLink { get; set; }

    [Parameter]
    public bool DisplayFooter { get; set; }
        = true;

    [Parameter]
    public bool DisplaySaveContinueButton { get; set; }
        = true;

    [Parameter]
    public TItem EditModel { get; set; }

    [Parameter]
    public string ItemName { get; set; }

    [Parameter]
    public string MenuItemLinkText { get; set; }

    [Parameter]
    public string MenuItemPath { get; set; }

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }

    [Parameter]
    public string PageFooterButtonText { get; set; }
        = "Back";

    [Parameter]
    public string PageFooterNavigationPath { get; set; }

    [Parameter]
    public string PageImageFileName { get; set; }

    [Parameter]
    public RenderFragment TimelineContent { get; set; }

    [Parameter]
    public bool UseMultipleButtons { get; set; }

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

    protected async Task Save(bool remainOnPage)
    {
        await OnSave.InvokeAsync(EditModel);

        if (!remainOnPage)
        {
            NavigationManager.NavigateTo(remainOnPage ? EditModel.ContinueNavigationPath : EditModel.ExitNavigationPath);
        }        
        
        Snackbar.Add($"{ItemName} {(ItemName.EndsWith("s") ? "were " : "was ")} {(EditModel.EditModeType == EditModeType.Add ? "added" : "updated")} successfully!", Severity.Success);
    }
}
