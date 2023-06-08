namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItem<TSaveViewModel, TViewModel> : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    protected TSaveViewModel ViewModel = (TSaveViewModel)Activator.CreateInstance(typeof(TSaveViewModel));

    protected async Task<TViewModel> Get(IQuery<TViewModel> request)
    {
        return await QueryRouter.Send(request);
    }

    protected async Task HandleValidSubmit(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected virtual void Initialize() { }
}
