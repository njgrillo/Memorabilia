namespace Memorabilia.Blazor.Pages.Project.ProjectTypeGrids;

public partial class ProjectMemorabiliaTeamGrid
{
    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<ProjectMemorabiliaTeamEditModel> AllItems { get; set; }
        = [];

    [Parameter]
    public List<ProjectMemorabiliaTeamEditModel> Items { get; set; } 
        = [];

    [Parameter]
    public int? ItemTypeId { get; set; }

    private ProjectMemorabiliaTeamEditModel _elementBeforeEdit;
    private string _search;

    protected override void OnInitialized()
    {
        Courier.Subscribe<ProjectMemorabiliaTeamAddedNotification>(OnProjectMemorabiliaTeamAdded);
    }

    public void OnProjectMemorabiliaTeamAdded(ProjectMemorabiliaTeamAddedNotification notification)
    {
        IEnumerable<ProjectMemorabiliaTeamEditModel> itemsToUpdate
            = AllItems.Where(item => item.Team.Id != notification.TeamId);

        if (!notification.Rank.HasValue ||
            notification.Rank.Value == 0 ||
            notification.Rank < itemsToUpdate.Where(item => item.Rank.HasValue).Min(item => item.Rank) ||
            notification.Rank > itemsToUpdate.Where(item => item.Rank.HasValue).Max(item => item.Rank))
            return;

        foreach (ProjectMemorabiliaTeamEditModel projectMemorabiliaTeamEditModel in itemsToUpdate)
        {
            if (!projectMemorabiliaTeamEditModel.Rank.HasValue || projectMemorabiliaTeamEditModel.Rank < notification.Rank)
                continue;

            projectMemorabiliaTeamEditModel.Rank += 1;
        }

        StateHasChanged();
    }

    private bool FilterFunc1(ProjectMemorabiliaTeamEditModel editModel)
        => FilterFunc(editModel, _search);

    private async Task AddMemorabiliaLink(ProjectMemorabiliaTeamEditModel editModel)
    {
        var parameters = new Dictionary<string, object>
        {
            ["TeamId"] = editModel.Team.Id
        };

        SetProjectDetailsParameters(editModel, parameters);

        if (ItemTypeId.HasValue)
            parameters.Add("ItemTypeId", ItemTypeId.Value);

        var dialogParameters = new DialogParameters
        {
            ["Parameters"] = parameters,
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SelectProjectMemorabiliaDialog>(string.Empty, dialogParameters, options); 
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["MemorabiliaId"].TryParse(out int memorabiliaId);

        editModel.MemorabiliaId = memorabiliaId;
        editModel.MemorabiliaFileName = results["MemorabiliaFileName"];
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Rank = ((ProjectMemorabiliaTeamEditModel)element).Rank,
            Upgrade = ((ProjectMemorabiliaTeamEditModel)element).Upgrade,
            PriorityTypeId = ((ProjectMemorabiliaTeamEditModel)element).PriorityTypeId,
            ProjectStatusTypeId = ((ProjectMemorabiliaTeamEditModel)element).ProjectStatusTypeId,
        };
    }

    private static bool FilterFunc(ProjectMemorabiliaTeamEditModel editModel, string search)
        => search.IsNullOrEmpty() ||
           (search.Equals("upgrade", StringComparison.OrdinalIgnoreCase) && editModel.Upgrade) ||
           editModel.PriorityTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           editModel.ProjectStatusTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           editModel.Team.Name.Contains(search, StringComparison.OrdinalIgnoreCase);

    private void MoveDown(int rank)
    {
        var itemToMove = Items.Single(item => item.Rank == rank);
        var nextItem = Items.SingleOrDefault(item => item.Rank == rank + 1);

        if (nextItem == null)
            return;

        itemToMove.Rank = rank + 1;
        nextItem.Rank = rank;
    }

    private void MoveToBottom(int rank)
    {
        var maxRank = Items.Max(item => item.Rank);

        if (rank == maxRank)
            return;

        var itemToMove = Items.Single(item => item.Rank == rank);

        foreach (var item in Items.Where(item => item.Rank > rank))
        {
            item.Rank--;
        }

        itemToMove.Rank = maxRank;
    }

    private void MoveToTop(int rank)
    {
        if (rank <= 1)
            return;

        var itemToMove = Items.Single(item => item.Rank == rank);

        foreach (var item in Items.Where(item => item.Rank < rank))
        {
            item.Rank++;
        }

        itemToMove.Rank = 1;
    }

    private void MoveUp(int rank)
    {
        if (rank <= 1)
            return;

        var itemToMove = Items.Single(item => item.Rank == rank);
        var previousItem = Items.SingleOrDefault(item => item.Rank == rank - 1);

        if (previousItem == null)
            return;

        itemToMove.Rank = rank - 1;
        previousItem.Rank = rank;
    }

    private void Remove(int projectMemorabiliaTeamId, int teamId, int? rank, int? itemTypeId)
    {
        var projectMemorabiliaTeam = projectMemorabiliaTeamId > 0
            ? Items.Single(item => item.Id == projectMemorabiliaTeamId)
            : Items.Single(item => item.Team.Id == teamId && item.ItemTypeId == itemTypeId && item.Rank == rank);

        projectMemorabiliaTeam.IsDeleted = true;

        var deletedRank = projectMemorabiliaTeam.Rank;

        foreach (var person in Items.Where(item => item.Rank > deletedRank))
        {
            person.Rank--;
        }
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((ProjectMemorabiliaTeamEditModel)element).Rank = _elementBeforeEdit.Rank;
        ((ProjectMemorabiliaTeamEditModel)element).Upgrade = _elementBeforeEdit.Upgrade;
        ((ProjectMemorabiliaTeamEditModel)element).PriorityTypeId = _elementBeforeEdit.PriorityTypeId;
        ((ProjectMemorabiliaTeamEditModel)element).ProjectStatusTypeId = _elementBeforeEdit.ProjectStatusTypeId;
    }

    protected static void SetProjectDetailsParameters(ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam,
        Dictionary<string, object> parameters)
    {
        var projectType = ProjectType.Find(projectMemorabiliaTeam.Project.ProjectTypeId);

        switch (projectType.ToString())
        {
            case "HelmetType":
                parameters.Add("HelmetTypeId", projectMemorabiliaTeam.Project.Helmet.HelmetTypeId);

                if (projectMemorabiliaTeam.Project.Helmet.HelmetFinishId.HasValue)
                    parameters.Add("HelmetFinishId", projectMemorabiliaTeam.Project.Helmet.HelmetFinishId);

                if (projectMemorabiliaTeam.Project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetSizeId", projectMemorabiliaTeam.Project.Helmet.SizeId);

                break;
            case "Team":
                parameters.Add("TeamId", projectMemorabiliaTeam.Project.Team.TeamId);

                if (projectMemorabiliaTeam.Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", projectMemorabiliaTeam.Project.Team.Year);

                break;
            default:
                break;
        }
    }

    private void UpdateRanks(object element)
    {
        var item = ((ProjectMemorabiliaTeamEditModel)element);

        if (_elementBeforeEdit.Rank == item.Rank)
            return;

        if (item.Rank < _elementBeforeEdit.Rank)
        {
            foreach (ProjectMemorabiliaTeamEditModel team in AllItems.Where(x => x.Id != item.Id && x.Rank < _elementBeforeEdit.Rank && x.Rank >= item.Rank))
            {
                team.Rank += 1;
            }
        }
        else
        {
            foreach (ProjectMemorabiliaTeamEditModel team in AllItems.Where(x => x.Id != item.Id && x.Rank > _elementBeforeEdit.Rank && x.Rank <= item.Rank))
            {
                team.Rank -= 1;
            }
        }

        StateHasChanged();
    }
}
