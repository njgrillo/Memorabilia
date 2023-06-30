namespace Memorabilia.Blazor.Pages.Project.ProjectTypeGrids;

public partial class ProjectPersonGrid
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<ProjectPersonEditModel> Items { get; set; } 
        = new();

    [Parameter]
    public int? ItemTypeId { get; set; }

    private ProjectPersonEditModel _elementBeforeEdit;
    private string _search;

    private bool FilterFunc1(ProjectPersonEditModel editModel)
        => FilterFunc(editModel, _search);

    private async Task AddAutographLink(ProjectPersonEditModel editModel)
    {
        var parameters = new Dictionary<string, object>
        {
            ["PersonId"] = editModel.Person.Id,
            ["ProjectTypeId"] = editModel.Project.ProjectTypeId
        };

        SetProjectDetailsParameters(editModel, parameters);

        if (!parameters.ContainsKey("ItemTypeId") && ItemTypeId.HasValue)
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

        var dialog = DialogService.Show<SelectProjectAutographDialog>("Select Autograph", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["AutographId"].TryParse(out int autographId);

        editModel.AutographId = autographId;
        editModel.AutographFileName = results["AutographFileName"];
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Rank = ((ProjectPersonEditModel)element).Rank,
            Upgrade = ((ProjectPersonEditModel)element).Upgrade,
            PriorityTypeId = ((ProjectPersonEditModel)element).PriorityTypeId,
            ProjectStatusTypeId = ((ProjectPersonEditModel)element).ProjectStatusTypeId,
        };
    }

    private static bool FilterFunc(ProjectPersonEditModel editModel, string search)
        => search.IsNullOrEmpty() ||
           (search.Equals("deceased", StringComparison.OrdinalIgnoreCase) && editModel.Deceased) ||
           (search.Equals("upgrade", StringComparison.OrdinalIgnoreCase) && editModel.Upgrade) ||
           editModel.PriorityTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           editModel.ProjectStatusTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           editModel.Person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!editModel.Person.Nickname.IsNullOrEmpty() && editModel.Person.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));

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

    private void Remove(int projectPersonId, int personId, int? itemTypeId)
    {
        var projectPerson = projectPersonId > 0
            ? Items.Single(item => item.Id == projectPersonId)
            : Items.Single(item => item.Person.Id == personId && item.ItemTypeId == itemTypeId);

        projectPerson.IsDeleted = true;

        var deletedRank = projectPerson.Rank;

        foreach (var person in Items.Where(item => item.Rank > deletedRank))
        {
            person.Rank--;
        }
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((ProjectPersonEditModel)element).Rank = _elementBeforeEdit.Rank;
        ((ProjectPersonEditModel)element).Upgrade = _elementBeforeEdit.Upgrade;
        ((ProjectPersonEditModel)element).PriorityTypeId = _elementBeforeEdit.PriorityTypeId;
        ((ProjectPersonEditModel)element).ProjectStatusTypeId = _elementBeforeEdit.ProjectStatusTypeId;
    }

    protected static void SetProjectDetailsParameters(ProjectPersonEditModel editModel, 
                                                      Dictionary<string, object> parameters)
    {
        var projectType = ProjectType.Find(editModel.Project.ProjectTypeId);

        switch (projectType.ToString())
        {
            case "BaseballType":
                parameters.Add("BaseballTypeId", editModel.Project.Baseball.BaseballTypeId);

                if (editModel.Project.Baseball.TeamId.HasValue)
                    parameters.Add("BaseballTypeTeamId", editModel.Project.Baseball.TeamId);

                if (editModel.Project.Baseball.Year.HasValue)
                    parameters.Add("BaseballTypeYear", editModel.Project.Baseball.Year);

                break;
            case "Card":
                parameters.Add("CardBrandId", editModel.Project.Card.BrandId);

                if (editModel.Project.Card.TeamId.HasValue)
                    parameters.Add("CardTeamId", editModel.Project.Card.TeamId);

                if (editModel.Project.Card.Year.HasValue)
                    parameters.Add("CardYear", editModel.Project.Card.Year);

                break;
            case "HallofFame":
                parameters.Add("HallOfFameSportLeagueLevelId", editModel.Project.HallOfFame.SportLeagueLevelId);

                if (editModel.Project.HallOfFame.ItemTypeId.HasValue)
                    parameters.Add("HallOfFameItemTypeId", editModel.Project.HallOfFame.ItemTypeId);

                if (editModel.Project.HallOfFame.Year.HasValue)
                    parameters.Add("HallOfFameYear", editModel.Project.HallOfFame.Year);

                break;
            case "HelmetType":
                parameters.Add("HelmetTypeId", editModel.Project.Helmet.HelmetTypeId);

                if (editModel.Project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetTypeSizeId", editModel.Project.Helmet.SizeId);

                break;
            case "ItemType":
                parameters.Add("ItemTypeId", editModel.Project.Item.ItemTypeId);
                parameters.Add("MultiSignedItem", editModel.Project.Item.MultiSignedItem);

                break;
            case "Team":
                parameters.Add("TeamId", editModel.Project.Team.TeamId);

                if (editModel.Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", editModel.Project.Team.Year);

                break;
            case "WorldSeries":
                parameters.Add("WorldSeriesTeamId", editModel.Project.WorldSeries.TeamId);

                if (editModel.Project.WorldSeries.ItemTypeId.HasValue)
                    parameters.Add("WorldSeriesItemTypeId", editModel.Project.WorldSeries.ItemTypeId);

                if (editModel.Project.WorldSeries.Year.HasValue)
                    parameters.Add("WorldSeriesYear", editModel.Project.WorldSeries.Year);

                break;
            default:
                break;
        }
    }

    private void UpdateRanks(object element)
    {
        var item = ((ProjectPersonEditModel)element);

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

    private async Task ViewImages(ProjectPersonEditModel projectPerson)
    {
        var parameters = new DialogParameters
        {
            ["AutographId"] = projectPerson.AutographId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AutographImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
