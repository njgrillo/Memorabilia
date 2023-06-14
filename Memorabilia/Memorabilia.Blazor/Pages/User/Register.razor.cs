namespace Memorabilia.Blazor.Pages.User;

public partial class Register
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public UserValidator Validator { get; set; }

    [Parameter]
    public EventCallback OnSaved { get; set; }

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts
        => ValidationResult != null
            ? ValidationResult.Errors
                              .Select(error => new Alert(error.ErrorMessage, Severity.Error))
                              .ToArray()
            : Array.Empty<Alert>();

    protected readonly UserEditModel EditModel 
        = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected async Task Save()
    {
        EditModel.ValidationResult = Validator.Validate(EditModel);

        if (!EditModel.ValidationResult.IsValid)
            return;

        var command = new AddUser(EditModel);

        await CommandRouter.Send(command);

        string message = !command.UserAlreadyExists
            ? "You have registered successfully!"
            : "User already exists with that email address.";

        Snackbar.Add(message, Severity.Success);

        if (command.UserAlreadyExists)
            return;

        await OnSaved.InvokeAsync();          
    }
}
