namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItem<TEditModel, TModel> : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    protected bool IsLoaded { get; set; }

    protected TEditModel EditModel 
        = (TEditModel)Activator.CreateInstance(typeof(TEditModel));

    protected async Task<TModel> Get(IQuery<TModel> request)
        => await QueryRouter.Send(request);

    protected async Task Save(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected virtual void Initialize() { }
}
