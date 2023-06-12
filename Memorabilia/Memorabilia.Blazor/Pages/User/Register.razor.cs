namespace Memorabilia.Blazor.Pages.User;

public partial class Register
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public EventCallback<int> OnSaved { get; set; }

    protected readonly UserEditModel Model 
        = new();

    protected async Task HandleValidSubmit()
    {
        var command = new AddUser.Command(Model);

        await CommandRouter.Send(command);
        await OnSaved.InvokeAsync(command.Id);            

        NavigationManager.NavigateTo("Home");
    }
}
