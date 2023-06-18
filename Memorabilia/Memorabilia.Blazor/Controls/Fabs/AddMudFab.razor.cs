namespace Memorabilia.Blazor.Controls.Fabs;

public partial class AddMudFab
{
    [Parameter]
    public EventCallback OnAdd { get; set; }

    public async Task Add()
    {
        await OnAdd.InvokeAsync();
    }
}
