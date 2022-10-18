using Memorabilia.Application.Features.Admin.People;
using System.Globalization;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class People : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private string _search;
        private PeopleViewModel _viewModel = new();

        private bool FilterFunc1(PersonViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetPeople());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Person");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.People.Single(person => person.Id == id);
            var viewModel = new SavePersonViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SavePerson.Command(viewModel));

            _viewModel.People.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private bool FilterFunc(PersonViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LegalName,
                                                                  search,
                                                                  CompareOptions.IgnoreNonSpace) > -1 ||
                   CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.DisplayName,
                                                                  search,
                                                                  CompareOptions.IgnoreNonSpace) > -1 ||
                   CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.FirstName,
                                                                  search,
                                                                  CompareOptions.IgnoreNonSpace) > -1 ||
                   CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LastName,
                                                                  search,
                                                                  CompareOptions.IgnoreNonSpace) > -1;
        }
    }
}
