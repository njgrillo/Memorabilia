#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class ViewDomainItem<T> : CommandQuery where T : ViewModel
{
    protected T ViewModel;

    protected async Task OnDelete(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected async Task OnLoad(IQuery<T> request)
    {
        ViewModel = await QueryRouter.Send(request);
    }
}
