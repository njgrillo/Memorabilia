namespace Memorabilia.Blazor.Controls;

public partial class EditPage<TItem> : INotifyPropertyChanged
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public RenderFragment AdditionalButtons { get; set; }

    [Parameter]
    public string BackNavigationPath { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool ContinueNavigation { get; set; }

    [Parameter]
    public string ContinueNavigationPath { get; set; }

    [Parameter]
    public bool DisplayFooter { get; set; } = true;

    [Parameter]
    public bool DisplaySaveContinueButton { get; set; } 
        = true;

    [Parameter]
    public EditModeType EditMode { get; set; }

    [Parameter]
    public string ExitNavigationPath { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public RenderFragment ImagePreview { get; set; }    

    [Parameter]
    public string ItemName { get; set; }

    [Parameter]
    public TItem Model { get; set; }    

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }

    [Parameter]
    public string PageFooterButtonText { get; set; } 
        = "Back";

    [Parameter]
    public string PageFooterNavigationPath { get; set; }

    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public bool PerformValidation { get; set; }

    [Parameter]
    public RenderFragment TimelineContent { get; set; }

    [Parameter]
    public bool UseMultipleButtons { get; set; }

    [Parameter]
    public ValidationResult ValidationResult { get; set; }

    public Alert[] ValidationResultAlerts 
        => ValidationResult != null
            ? ValidationResult.Errors
                              .Select(error => new Alert(error.ErrorMessage, Severity.Error))
                              .ToArray()
            : Array.Empty<Alert>();

    private bool _continue;

    public EditPage()
    {
        PropertyChanged += EditPage_PropertyChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected async Task HandleValidSubmit()
    {
        await OnSave.InvokeAsync(Model);

        if (!PerformValidation)
            NavigateAway();
    }

    private void EditPage_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (!PerformValidation)
            return;

        if (e.PropertyName == nameof(ContinueNavigationPath) || 
            (e.PropertyName == nameof(ContinueNavigation) && ContinueNavigation))
        {
            if (ValidationResult?.IsValid ?? false)
                NavigateAway();
        }
    }

    private void NavigateAway()
    {
        NavigationManager.NavigateTo(_continue ? ContinueNavigationPath : ExitNavigationPath);
        Snackbar.Add($"{ItemName} {(ItemName.EndsWith("s") ? "were " : "was ")} {(EditMode == EditModeType.Add ? "added" : "updated")} successfully!", Severity.Success);
    }
}
