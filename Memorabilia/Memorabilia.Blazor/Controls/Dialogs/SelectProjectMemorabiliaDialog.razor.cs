namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class SelectProjectMemorabiliaDialog
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public Dictionary<string, object> Parameters { get; set; }

    protected int UserId
        => Parameters.ContainsKey("UserId")
        ? (int)Parameters["UserId"]
        : 0;

    private MemorabiliaItemViewModel[] _viewModel = Array.Empty<MemorabiliaItemViewModel>();

    protected override async Task OnInitializedAsync()
    {
        if (!Parameters.Any())
            return;

        _viewModel = await QueryRouter.Send(new GetProjectMemorabiliaTeamLinks(Parameters));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(MemorabiliaItemViewModel memorabilia)
    {
        var results = new Dictionary<string, string>()
        {
            { "MemorabiliaId", memorabilia.Id.ToString() },
            { "MemorabiliaFileName", memorabilia.ImageFileName }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
