namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class EditMemorabiliaPage<TItem> where TItem : MemorabiliaItemEditModel
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public new TItem EditModel { get; set; }

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }

    protected async Task Save()
    {
        await OnSave.InvokeAsync();
    }
}
