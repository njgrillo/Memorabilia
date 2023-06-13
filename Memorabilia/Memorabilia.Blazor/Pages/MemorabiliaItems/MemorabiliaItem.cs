namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public abstract class MemorabiliaItem<T> 
    : CommandQuery where T : ItemEditModel
{
    [Parameter]
    public int MemorabiliaId { get; set; }

    public T EditModel 
        = (T)Activator.CreateInstance(typeof(T));

    protected override void OnInitialized()
    {
        EditModel.MemorabiliaId = MemorabiliaId;
    }
}
