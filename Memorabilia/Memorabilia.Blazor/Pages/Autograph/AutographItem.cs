#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph;

public abstract class AutographItem<T> : ImagePage where T : SaveViewModel
{
    [Parameter]
    public int AutographId { get; set; }

    public T ViewModel = (T)Activator.CreateInstance(typeof(T));
}
