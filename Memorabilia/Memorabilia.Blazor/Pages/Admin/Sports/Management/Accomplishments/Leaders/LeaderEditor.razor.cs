namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.Accomplishments.Leaders;

public partial class LeaderEditor
{
    [Parameter]
    public List<LeaderEditModel> Leaders { get; set; }
        = [];

    [Parameter]
    public EventCallback<LeaderEditModel> OnLeaderAdded { get; set; }

    [Parameter]
    public EventCallback<LeaderEditModel> OnLeaderDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    private async Task Add()
    {
        await OnLeaderAdded.InvokeAsync(Leaders.First());
    }

    private async Task Delete(LeaderEditModel Leader)
    {
        await OnLeaderDeleted.InvokeAsync(Leader);
    }
}
