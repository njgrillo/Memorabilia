namespace Memorabilia.Blazor.Pages.Admin;

public abstract class ViewDomainItem<T> 
    : CommandQuery where T : Model
{
    protected T Model 
        = (T)Activator.CreateInstance(typeof(T));

    protected async Task OnDelete(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected async Task OnLoad(IQuery<T> request)
    {
        Model = await QueryRouter.Send(request);
    }
}
