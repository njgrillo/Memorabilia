﻿using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.ItemTypeSizes;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSizes
{
    public partial class ItemTypeSizes : ComponentBase
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
        private ItemTypeSizesViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeSizeViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeSizes.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Size");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeSizes.Single(ItemTypeSize => ItemTypeSize.Id == id);
            var viewModel = new SaveItemTypeSizeViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeSize.Command(viewModel)).ConfigureAwait(false);

            _viewModel.ItemTypeSizes.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeSizeViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
