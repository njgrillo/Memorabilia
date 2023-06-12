namespace Memorabilia.Blazor.Pages.User;

public partial class Login
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public EventCallback<int> UserValidated { get; set; }

    private readonly LoginUserModel _viewModel = new();

    protected async Task HandleValidSubmit()
    {
        var viewModel = new UserModel(await QueryRouter.Send(new GetUser(_viewModel.Username, _viewModel.Password)));

        if (!viewModel.IsValid || viewModel.Id == 0)
        {
            //TODO: Didn't find user

            return;
        }

        await UserValidated.InvokeAsync(viewModel.Id);      
    }

    protected void OnLoad()
    {
        //NavigationManager.NavigateTo("Home");
    }
}
