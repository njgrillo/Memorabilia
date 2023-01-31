namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class EditMemorabiliaPage<TItem> where TItem : MemorabiliaItemEditViewModel
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public TItem Item { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }    

    protected async Task Load()
    {
        await OnLoad.InvokeAsync();
    }

    protected async Task Save()
    {
        await OnSave.InvokeAsync();
    }
}
