namespace Memorabilia.Blazor.Pages.Forum;

public partial class CreateForumTopic
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ForumValidator Validator { get; set; }

    protected ForumTopicEditModel EditModel { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    protected override void OnInitialized()
    {
        EditModel.CreatedByUser = ApplicationStateService.CurrentUser;
    }

    protected async Task Save()
    {
        var command = new SaveForumTopic.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        NavigationManager.NavigateTo($"{NavigationPath.ForumTopic}/{DataProtectorService.EncryptId(command.Id)}");

        Snackbar.Add("Forum Topic Created Successfully!", Severity.Success);
    }
}
