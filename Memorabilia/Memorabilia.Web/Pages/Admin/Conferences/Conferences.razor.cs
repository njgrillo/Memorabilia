

using Memorabilia.Application.Features.Admin.Conferences;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Conferences
{
    public partial class Conferences : ComponentBase
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
        private ConferencesViewModel _viewModel = new();

        private bool FilterFunc1(ConferenceViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetConferences.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Conference");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Conferences.Single(conference => conference.Id == id);
            var viewModel = new SaveConferenceViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveConference.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Conferences.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ConferenceViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.Abbreviation.IsNullOrEmpty() &&
                    viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
