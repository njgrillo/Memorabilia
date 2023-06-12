namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class EditMemorabiliaPage<TItem> where TItem : MemorabiliaItemEditModel
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public TItem Item { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback<TItem> OnSave { get; set; }

    [Parameter]
    public bool PerformValidation { get; set; } = true;

    protected async Task Load()
    {
        await OnLoad.InvokeAsync();
    }

    protected async Task Save()
    {
        await OnSave.InvokeAsync();
    }
}
