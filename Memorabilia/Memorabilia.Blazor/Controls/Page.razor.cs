#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class Page : ComponentBase
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private bool PageLoaded;

    protected override async Task OnInitializedAsync()
    {
        await OnLoad.InvokeAsync();

        PageLoaded = true;
    }
}
