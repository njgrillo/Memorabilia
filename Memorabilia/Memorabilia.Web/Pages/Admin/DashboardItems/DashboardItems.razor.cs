﻿using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.DashboardItems;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.DashboardItems
{
    public partial class DashboardItems : ComponentBase
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
        private DashboardItemsViewModel _viewModel = new();

        private bool FilterFunc1(DashboardItemViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetDashboardItems.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Dashboard Item");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        protected async Task Delete(int id)
        {
            var deletedItem = _viewModel.DashboardItems.Single(dashboardItem => dashboardItem.Id == id);
            var viewModel = new SaveDashboardItemViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveDashboardItem.Command(viewModel)).ConfigureAwait(false);

            _viewModel.DashboardItems.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(DashboardItemViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Description.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
