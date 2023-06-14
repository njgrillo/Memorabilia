namespace Memorabilia.Web.Controls;

public partial class PageLoader
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    protected bool PageLoaded;

    protected override async Task OnInitializedAsync()
    {
        await OnLoad.InvokeAsync();

        PageLoaded = true;
    }
}
