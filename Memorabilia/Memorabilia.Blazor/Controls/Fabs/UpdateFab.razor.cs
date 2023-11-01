namespace Memorabilia.Blazor.Controls.Fabs;

public partial class UpdateFab
{
    [Parameter]
    public EventCallback OnUpdate { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task Update()
    {
        await OnUpdate.InvokeAsync();
    }
}
