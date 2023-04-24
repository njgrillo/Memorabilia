namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectEditor : ImagePage
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private SaveProjectPersonViewModel _elementBeforeEdit;
    private string _search;
    private SaveProjectViewModel _viewModel = new();

    private bool FilterFunc1(SaveProjectPersonViewModel projectPersonViewModel)
        => FilterFunc(projectPersonViewModel, _search);

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveProject.Command(_viewModel));
    }

    protected async Task OnLoad()
    {            
        if (UserId == 0)
            NavigationManager.NavigateTo("Login");

        if (Id == 0)
        {
            _viewModel = new SaveProjectViewModel
            {
                UserId = UserId
            };

            return;
        }

        _viewModel = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(Id)));
    }

    private async Task AddProjectPerson()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = _viewModel.ItemTypeId,
        };
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };
        var dialog = DialogService.Show<AddProjectPersonDialog>("Add Project Person", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        SaveProjectPersonViewModel projectPerson 
            = (SaveProjectPersonViewModel)result.Data;

        _viewModel.People.Add(projectPerson);
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Rank = ((SaveProjectPersonViewModel)element).Rank,
            Upgrade = ((SaveProjectPersonViewModel)element).Upgrade,
            PriorityTypeId = ((SaveProjectPersonViewModel)element).PriorityTypeId,
            ProjectStatusTypeId = ((SaveProjectPersonViewModel)element).ProjectStatusTypeId,
        };
    }

    private static bool FilterFunc(SaveProjectPersonViewModel projectPersonViewModel, string search)
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
        var itemToMove = _viewModel.People.Single(person => person.Rank == rank);
        var nextItem = _viewModel.People.SingleOrDefault(person => person.Rank == rank + 1);

        if (nextItem == null)
            return;

        itemToMove.Rank = rank + 1;
        nextItem.Rank = rank;
    }

    private void MoveToBottom(int rank)
    {
        var maxRank = _viewModel.People.Max(person => person.Rank);

        if (rank == maxRank)
            return;

        var itemToMove = _viewModel.People.Single(person => person.Rank == rank);

        foreach (var item in _viewModel.People.Where(person => person.Rank > rank))
        {
            item.Rank--;
        }

        itemToMove.Rank = maxRank;
    }

    private void MoveToTop(int rank)
    {
        if (rank <= 1)
            return;

        var itemToMove = _viewModel.People.Single(person => person.Rank == rank);

        foreach (var item in _viewModel.People.Where(person => person.Rank < rank))
        {
            item.Rank++;
        }

        itemToMove.Rank = 1;
    }

    private void MoveUp(int rank)
    {
        if (rank <= 1)
            return;

        var itemToMove = _viewModel.People.Single(person => person.Rank == rank);
        var previousItem = _viewModel.People.SingleOrDefault(person => person.Rank == rank - 1);

        if (previousItem == null)
            return;

        itemToMove.Rank = rank - 1;
        previousItem.Rank = rank;
    }

    private void Remove(int projectPersonId, int personId, int? itemTypeId)
    {
        var projectPerson = projectPersonId > 0
            ? _viewModel.People.Single(person => person.Id == projectPersonId)
            : _viewModel.People.Single(person => person.Person.Id == personId && person.ItemTypeId == itemTypeId);

        projectPerson.IsDeleted = true;

        var deletedRank = projectPerson.Rank;

        foreach(var person in _viewModel.People.Where(person => person.Rank > deletedRank))
        {
            person.Rank--;
        }
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((SaveProjectPersonViewModel)element).Rank = _elementBeforeEdit.Rank;
        ((SaveProjectPersonViewModel)element).Upgrade = _elementBeforeEdit.Upgrade;
        ((SaveProjectPersonViewModel)element).PriorityTypeId = _elementBeforeEdit.PriorityTypeId;
        ((SaveProjectPersonViewModel)element).ProjectStatusTypeId = _elementBeforeEdit.ProjectStatusTypeId;
    }

    private void UpdateRanks(object element)
    {
        var item = ((SaveProjectPersonViewModel)element);

        if (_elementBeforeEdit.Rank == item.Rank)
            return;

        if (item.Rank < _elementBeforeEdit.Rank)
        {
            foreach (var person in _viewModel.People.Where(x => x.Rank < _elementBeforeEdit.Rank && x.Rank >= item.Rank))
            {
                if (person.Id == item.Id)
                    continue;

                person.Rank += 1;
            }
        }
        else
        {
            foreach (var person in _viewModel.People.Where(x => x.Rank > _elementBeforeEdit.Rank && x.Rank <= item.Rank))
            {
                if (person.Id == item.Id)
                    continue;

                person.Rank -= 1;
            }
        }

        StateHasChanged();
    } 
}
