namespace Memorabilia.Blazor.Pages.User;

public partial class Login
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public EventCallback<int> UserValidated { get; set; }

    protected readonly LoginUserModel Model = new();

    protected async Task HandleValidSubmit()
    {
        var model = new UserModel(await QueryRouter.Send(new GetUser(Model.Username, Model.Password)));

        if (!model.IsValid || model.Id == 0)
        {
            //TODO: Didn't find user

            return;
        }

        await UserValidated.InvokeAsync(model.Id);      
    }

    protected void OnLoad()
    {
        //NavigationManager.NavigateTo("Home");
    }
}
