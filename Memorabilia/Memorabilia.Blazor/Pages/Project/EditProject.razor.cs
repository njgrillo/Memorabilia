#nullable disable

namespace Memorabilia.Blazor.Pages.Project
{
    public partial class EditProject : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _canAddProjectPerson = true;
        private bool _canEditPerson = true;
        private bool _canUpdateProjectPerson;
        private SaveProjectPersonViewModel _projectPersonViewModel = new();
        private SaveProjectViewModel _viewModel = new();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveProject.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId");

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            if (Id == 0)
            {
                _viewModel = new SaveProjectViewModel
                {
                    UserId = userId.Value
                };

                return;
            }

            _viewModel = new SaveProjectViewModel(await QueryRouter.Send(new GetProject.Query(Id)).ConfigureAwait(false));
        }

        private void AddProjectPerson()
        {
            if (_viewModel.ItemTypeId > 0)
                _projectPersonViewModel.ItemTypeId = _viewModel.ItemTypeId;

            _viewModel.People.Add(_projectPersonViewModel);
            _projectPersonViewModel = new SaveProjectPersonViewModel();
        }

        private void Edit(SaveProjectPersonViewModel projectPerson)
        {
            _projectPersonViewModel.Person = projectPerson.Person;
            _projectPersonViewModel.ItemTypeId = projectPerson.ItemTypeId;
            _projectPersonViewModel.PriorityTypeId = projectPerson.PriorityTypeId;
            _projectPersonViewModel.Rank = projectPerson.Rank;
            _projectPersonViewModel.Upgrade = projectPerson.Upgrade;

            _canAddProjectPerson = false;
            _canEditPerson = false;
            _canUpdateProjectPerson = true;
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
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _projectPersonViewModel.Person = person;
        }

        private void UpdateProjectPerson()
        {
            var person = _viewModel.People.Single(person => person.Person.Id == _projectPersonViewModel.Person.Id);

            person.PriorityTypeId = _projectPersonViewModel.PriorityTypeId;
            person.Rank = _projectPersonViewModel.Rank;
            person.Upgrade = _projectPersonViewModel.Upgrade;

            _projectPersonViewModel = new SaveProjectPersonViewModel();

            _canAddProjectPerson = true;
            _canEditPerson = true;
            _canUpdateProjectPerson = false;
        }
    }
}
