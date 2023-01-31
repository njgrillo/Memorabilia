namespace Memorabilia.Blazor.Controls;

public partial class EditPage<TItem> : ImagePage, INotifyPropertyChanged
{
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
    public string ImageFileName { get; set; }

    [Parameter]
    public RenderFragment ImagePreview { get; set; }    

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
    public bool PerformValidation { get; set; }

    [Parameter]
    public RenderFragment TimelineContent { get; set; }

    [Parameter]
    public bool UseMultipleButtons { get; set; }

    [Parameter]
    public ValidationResult ValidationResult { get; set; }

    public Alert[] ValidationResultAlerts => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();

    private bool _continue;

    public EditPage()
    {
        PropertyChanged += EditPage_PropertyChanged;
    }

    protected async Task HandleValidSubmit()
    {
        await OnSave.InvokeAsync(Model);

        if (!PerformValidation)
            NavigateAway();
    }

    protected async Task Load()
    {
        await OnLoad.InvokeAsync();
    }

    private void EditPage_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ContinueNavigationPath))
        {
            if (ValidationResult != null && ValidationResult.IsValid)
                NavigateAway();
        }
    }

    private void NavigateAway()
    {
        NavigationManager.NavigateTo(_continue ? ContinueNavigationPath : ExitNavigationPath);
        Snackbar.Add($"{ItemName} {(ItemName.EndsWith("s") ? "were " : "was ")} {(EditMode == EditModeType.Add ? "added" : "updated")} successfully!", Severity.Success);
    }
}
