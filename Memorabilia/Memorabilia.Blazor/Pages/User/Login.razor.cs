#nullable disable

namespace Memorabilia.Blazor.Pages.User;

public partial class Login : ImagePage
{   
    [Parameter]
    public EventCallback<int> UserValidated { get; set; }

    private readonly LoginUserViewModel _viewModel = new();

    protected async Task HandleValidSubmit()
    {
        var viewModel = await QueryRouter.Send(new GetUser.Query(_viewModel.Username, _viewModel.Password));

        if (!viewModel.IsValid || viewModel.Id == 0)
        {
            //TODO: Didn't find user

            return;
        }

        await UserValidated.InvokeAsync(viewModel.Id);            

        NavigationManager.NavigateTo("Home");
    }

    protected void OnLoad()
    {
        //NavigationManager.NavigateTo("Home");
    }
}
