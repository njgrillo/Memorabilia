﻿using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.ItemTypeLevel;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeLevels
{
    public partial class ItemTypeLevels : ComponentBase
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
        private ItemTypeLevelsViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeLevelViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeLevels.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Level");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeLevels.Single(ItemTypeLevel => ItemTypeLevel.Id == id);
            var viewModel = new SaveItemTypeLevelViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeLevel.Command(viewModel)).ConfigureAwait(false);

            _viewModel.ItemTypeLevels.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeLevelViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
