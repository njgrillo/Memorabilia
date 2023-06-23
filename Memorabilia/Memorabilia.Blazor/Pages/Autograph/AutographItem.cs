namespace Memorabilia.Blazor.Pages.Autograph;

public abstract class AutographItem<T> 
    : CommandQuery where T : EditModel
{
    [Parameter]
    public int AutographId { get; set; }

    protected EditModeType EditMode { get; set; }

    protected bool IsLoaded { get; set; }

    public T Model 
        = (T)Activator.CreateInstance(typeof(T));
}
