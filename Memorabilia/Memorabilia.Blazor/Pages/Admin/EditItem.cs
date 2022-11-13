#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItem<TSaveViewModel, TViewModel> : ImagePage
{
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
