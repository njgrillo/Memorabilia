namespace Memorabilia.Blazor.Controls.Fabs;

public partial class AddUpdateFab
{
    [Parameter]
    public EditModeType EditMode { get; set; }
        = EditModeType.Add;

    [Parameter]
    public EventCallback OnAdd { get; set; }

    [Parameter]
    public EventCallback OnUpdate { get; set; }

    protected async Task Add()
    {
        await OnAdd.InvokeAsync();
    }

    protected async Task Update()
    {
        await OnUpdate.InvokeAsync();
    }
}
