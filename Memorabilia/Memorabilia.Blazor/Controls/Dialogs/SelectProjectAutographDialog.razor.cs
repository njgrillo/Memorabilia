namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class SelectProjectAutographDialog
{
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

    private AutographViewModel[] _viewModel = Array.Empty<AutographViewModel>();

    protected override async Task OnInitializedAsync()
    {
        if (!Parameters.Any())
            return;

        _viewModel = await QueryRouter.Send(new GetProjectPersonAutographLinks(Parameters));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(AutographViewModel autograph)
    {
        var results = new Dictionary<string, string>()
        {
            { "AutographId", autograph.Id.ToString() },
            { "AutographFileName", autograph.PrimaryImageName }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
