namespace Memorabilia.Blazor.Pages.Project.ProjectTypeGrids;

public partial class ProjectPersonGrid
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<ProjectPersonEditModel> Items { get; set; } = new();

    [Parameter]
    public int? ItemTypeId { get; set; }

    private ProjectPersonEditModel _elementBeforeEdit;
    private string _search;

    private bool FilterFunc1(ProjectPersonEditModel projectPersonViewModel)
        => FilterFunc(projectPersonViewModel, _search);

    private async Task AddAutographLink(ProjectPersonEditModel projectPerson)
    {
        var parameters = new Dictionary<string, object>
        {
            ["UserId"] = projectPerson.UserId,
            ["PersonId"] = projectPerson.Person.Id
        };

        SetProjectDetailsParameters(projectPerson, parameters);

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

        _ = int.TryParse(results["AutographId"], out int autographId);

        projectPerson.AutographId = autographId;
        projectPerson.AutographFileName = results["AutographFileName"];
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

    private static bool FilterFunc(ProjectPersonEditModel projectPersonViewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               (search.Equals("deceased", StringComparison.OrdinalIgnoreCase) && projectPersonViewModel.Deceased) ||
               (search.Equals("upgrade", StringComparison.OrdinalIgnoreCase) && projectPersonViewModel.Upgrade) ||
               projectPersonViewModel.PriorityTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               projectPersonViewModel.ProjectStatusTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               projectPersonViewModel.Person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!projectPersonViewModel.Person.Nickname.IsNullOrEmpty() && projectPersonViewModel.Person.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
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

    protected static void SetProjectDetailsParameters(ProjectPersonEditModel projectPerson, 
        Dictionary<string, object> parameters)
    {
        var projectType = ProjectType.Find(projectPerson.Project.ProjectTypeId);

        switch (projectType.ToString())
        {
            case "BaseballType":
                parameters.Add("BaseballTypeId", projectPerson.Project.Baseball.BaseballTypeId);

                if (projectPerson.Project.Baseball.TeamId.HasValue)
                    parameters.Add("BaseballTypeTeamId", projectPerson.Project.Baseball.TeamId);

                if (projectPerson.Project.Baseball.Year.HasValue)
                    parameters.Add("BaseballTypeYear", projectPerson.Project.Baseball.Year);

                break;
            case "Card":
                parameters.Add("CardBrandId", projectPerson.Project.Card.BrandId);

                if (projectPerson.Project.Card.TeamId.HasValue)
                    parameters.Add("CardTeamId", projectPerson.Project.Card.TeamId);

                if (projectPerson.Project.Card.Year.HasValue)
                    parameters.Add("CardYear", projectPerson.Project.Card.Year);

                break;
            case "HallofFame":
                parameters.Add("HallOfFameSportLeagueLevelId", projectPerson.Project.HallOfFame.SportLeagueLevelId);

                if (projectPerson.Project.HallOfFame.ItemTypeId.HasValue)
                    parameters.Add("HallOfFameItemTypeId", projectPerson.Project.HallOfFame.ItemTypeId);

                if (projectPerson.Project.HallOfFame.Year.HasValue)
                    parameters.Add("HallOfFameYear", projectPerson.Project.HallOfFame.Year);

                break;
            case "HelmetType":
                parameters.Add("HelmetTypeId", projectPerson.Project.Helmet.HelmetTypeId);

                if (projectPerson.Project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetTypeSizeId", projectPerson.Project.Helmet.SizeId);

                break;
            case "ItemType":
                parameters.Add("ItemTypeId", projectPerson.Project.Item.ItemTypeId);
                parameters.Add("MultiSignedItem", projectPerson.Project.Item.MultiSignedItem);

                break;
            case "Team":
                parameters.Add("TeamId", projectPerson.Project.Team.TeamId);

                if (projectPerson.Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", projectPerson.Project.Team.Year);

                break;
            case "WorldSeries":
                parameters.Add("WorldSeriesTeamId", projectPerson.Project.WorldSeries.TeamId);

                if (projectPerson.Project.WorldSeries.ItemTypeId.HasValue)
                    parameters.Add("WorldSeriesItemTypeId", projectPerson.Project.WorldSeries.ItemTypeId);

                if (projectPerson.Project.WorldSeries.Year.HasValue)
                    parameters.Add("WorldSeriesYear", projectPerson.Project.WorldSeries.Year);

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
            ["AutographId"] = projectPerson.AutographId,
            ["UserId"] = projectPerson.UserId
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
