namespace Memorabilia.Blazor.Pages.Project.ProjectTypeGrids;

public partial class ProjectMemorabiliaTeamGrid
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<SaveProjectMemorabiliaTeamViewModel> Items { get; set; } = new();

    [Parameter]
    public int? ItemTypeId { get; set; }

    private SaveProjectMemorabiliaTeamViewModel _elementBeforeEdit;
    private string _search;

    private bool FilterFunc1(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeamViewModel)
        => FilterFunc(projectMemorabiliaTeamViewModel, _search);

    private async Task AddMemorabiliaLink(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeam)
    {
        var parameters = new Dictionary<string, object>
        {
            ["UserId"] = projectMemorabiliaTeam.UserId,
            ["TeamId"] = projectMemorabiliaTeam.Team.Id,
            ["DomainImageRootPath"] = ImagePath.DomainImageRootPath,
            ["ImageRootPath"] = Path.Combine(ImagePath.MemorabiliaImageRootPath, projectMemorabiliaTeam.UserId.ToString())
        };

        SetProjectDetailsParameters(projectMemorabiliaTeam, parameters);

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

        var dialog = DialogService.Show<SelectProjectMemorabiliaDialog>("Select Autograph", dialogParameters, options); 
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = int.TryParse(results["MemorabiliaId"], out int memorabiliaId);

        projectMemorabiliaTeam.MemorabiliaId = memorabiliaId;
        projectMemorabiliaTeam.MemorabiliaFileName = results["MemorabiliaFileName"];
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Rank = ((SaveProjectMemorabiliaTeamViewModel)element).Rank,
            Upgrade = ((SaveProjectMemorabiliaTeamViewModel)element).Upgrade,
            PriorityTypeId = ((SaveProjectMemorabiliaTeamViewModel)element).PriorityTypeId,
            ProjectStatusTypeId = ((SaveProjectMemorabiliaTeamViewModel)element).ProjectStatusTypeId,
        };
    }

    private static bool FilterFunc(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeamViewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               (search.Equals("upgrade", StringComparison.OrdinalIgnoreCase) && projectMemorabiliaTeamViewModel.Upgrade) ||
               projectMemorabiliaTeamViewModel.PriorityTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               projectMemorabiliaTeamViewModel.ProjectStatusTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               projectMemorabiliaTeamViewModel.Team.Name.Contains(search, StringComparison.OrdinalIgnoreCase);
    }

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
        ((SaveProjectMemorabiliaTeamViewModel)element).Rank = _elementBeforeEdit.Rank;
        ((SaveProjectMemorabiliaTeamViewModel)element).Upgrade = _elementBeforeEdit.Upgrade;
        ((SaveProjectMemorabiliaTeamViewModel)element).PriorityTypeId = _elementBeforeEdit.PriorityTypeId;
        ((SaveProjectMemorabiliaTeamViewModel)element).ProjectStatusTypeId = _elementBeforeEdit.ProjectStatusTypeId;
    }

    protected static void SetProjectDetailsParameters(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeam,
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
        var item = ((SaveProjectMemorabiliaTeamViewModel)element);

        if (_elementBeforeEdit.Rank == item.Rank)
            return;

        if (item.Rank < _elementBeforeEdit.Rank)
        {
            foreach (var person in Items.Where(x => x.Rank < _elementBeforeEdit.Rank && x.Rank >= item.Rank))
            {
                if (person.Id == item.Id)
                    continue;

                person.Rank += 1;
            }
        }
        else
        {
            foreach (var person in Items.Where(x => x.Rank > _elementBeforeEdit.Rank && x.Rank <= item.Rank))
            {
                if (person.Id == item.Id)
                    continue;

                person.Rank -= 1;
            }
        }

        StateHasChanged();
    }

    private async Task ViewImages(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeam)
    {
        var parameters = new DialogParameters
        {
            ["MemorabiliaId"] = projectMemorabiliaTeam.MemorabiliaId,
            ["UserId"] = projectMemorabiliaTeam.UserId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<MemorabiliaImageViewerDialog>("View Images", parameters, options);
        
        await dialog.Result;
    }
}
