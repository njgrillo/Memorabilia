#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class ViewDomainItem<T> : CommandQuery where T : ViewModel
{
    protected T ViewModel = (T)Activator.CreateInstance(typeof(T));

    protected async Task OnDelete(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected async Task OnLoad(IQuery<T> request)
    {
        ViewModel = await QueryRouter.Send(request);
        //ViewModel = (T)Activator.CreateInstance(typeof(T), await QueryRouter.Send(request));
    }
}
