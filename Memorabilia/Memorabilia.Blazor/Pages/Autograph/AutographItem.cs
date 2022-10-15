#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph;

public abstract class AutographItem<T> : CommandQuery where T : SaveViewModel
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    public T ViewModel = (T)Activator.CreateInstance(typeof(T));
}
