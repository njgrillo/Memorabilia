﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Project;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Project
{
    public partial class Projects : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private ProjectsViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId");

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel = await QueryRouter.Send(new GetProjects.Query(userId.Value)).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Project");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        protected async Task Delete(int id)
        {
            var deletedItem = _viewModel.Projects.Single(project => project.Id == id);
            var viewModel = new SaveProjectViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveProject.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Projects.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }
    }
}
