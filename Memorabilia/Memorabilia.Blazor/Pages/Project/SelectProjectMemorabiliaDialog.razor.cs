﻿namespace Memorabilia.Blazor.Pages.Project;

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

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public Dictionary<string, object> Parameters { get; set; }

    [Parameter]
    public int ProjectTypeId { get; set; }

    protected MemorabiliaModel[] Model 
        = Array.Empty<MemorabiliaModel>();

    protected ProjectType ProjectType
        => ProjectType.Find(ProjectTypeId);

    protected override async Task OnInitializedAsync()
    {
        if (!Parameters.Any())
            return;

        Entity.Memorabilia[] memorabilia
            = await ProjectMemorabiliaTeamLinkService.GetMemorabilia(ProjectType, Parameters);

        Model = memorabilia.Any()
            ? memorabilia.Select(item => new MemorabiliaModel(item))
                         .ToArray()
            : Array.Empty<MemorabiliaModel>();
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
