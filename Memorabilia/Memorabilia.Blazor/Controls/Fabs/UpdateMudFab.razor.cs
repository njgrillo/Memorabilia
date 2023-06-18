namespace Memorabilia.Blazor.Controls.Fabs;

public partial class UpdateMudFab
{
    [Parameter]
    public EventCallback OnUpdate { get; set; }

    public async Task Update()
    {
        await OnUpdate.InvokeAsync();
    }
}
