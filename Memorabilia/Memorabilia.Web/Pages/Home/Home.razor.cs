namespace Memorabilia.Web.Pages.Home;

public partial class Home
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Mediator.Publish(new UserLoggedInNotification());
    }
}
