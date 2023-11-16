using Memorabilia.Application.Services.Interfaces;
using Memorabilia.Application.Services.Projects;

namespace Memorabilia.Blazor.Pages.Project;

public partial class SelectProjectMemorabiliaDialog
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ProjectMemorabiliaTeamLinkService ProjectMemorabiliaTeamLinkService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public Dictionary<string, object> Parameters { get; set; }

    [Parameter]
    public int ProjectTypeId { get; set; }

    protected MemorabiliaModel[] Model 
        = [];

    protected ProjectType ProjectType
        => ProjectType.Find(ProjectTypeId);

    protected override async Task OnInitializedAsync()
    {
        if (Parameters.IsNullOrEmpty())
            return;

        Entity.Memorabilia[] memorabilia
            = await ProjectMemorabiliaTeamLinkService.GetMemorabilia(ProjectType, Parameters);

        Model = memorabilia.HasAny()
            ? memorabilia.Select(item => new MemorabiliaModel(item))
                         .ToArray()
            : [];
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(MemorabiliaModel memorabilia)
    {
        var results = new Dictionary<string, string>()
        {
            { "MemorabiliaId", memorabilia.Id.ToString() },
            { "MemorabiliaFileName", memorabilia.ImageFileName }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
