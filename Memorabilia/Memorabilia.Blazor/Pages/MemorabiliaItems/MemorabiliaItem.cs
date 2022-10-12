#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public abstract class MemorabiliaItem<T> : CommandQuery where T : SaveItemViewModel
{
    [Parameter]
    public int MemorabiliaId { get; set; }

    public T ViewModel = (T)Activator.CreateInstance(typeof(T));

    protected override void OnInitialized()
    {
        ViewModel.MemorabiliaId = MemorabiliaId;
    }
}
