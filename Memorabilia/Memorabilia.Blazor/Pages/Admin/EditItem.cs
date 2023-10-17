namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItem<TEditModel, TModel> : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int Id { get; set; }

    protected bool IsLoaded { get; set; }

    protected TEditModel EditModel 
        = (TEditModel)Activator.CreateInstance(typeof(TEditModel));

    protected async Task<TModel> Get(IQuery<TModel> request)
        => await Mediator.Send(request);

    protected async Task Save(ICommand command)
    {
        await Mediator.Send(command);
    }

    protected virtual void Initialize() { }
}
