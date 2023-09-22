namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class ComposeUserMessage
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public UserMessageValidator Validator { get; set; }

    protected UserMessageEditModel EditModel { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected async Task Send()
    {
        var command = new AddUserMessage.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Message sent successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.Messages);
    }
}
