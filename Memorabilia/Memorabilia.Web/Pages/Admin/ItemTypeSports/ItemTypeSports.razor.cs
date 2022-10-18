﻿using Memorabilia.Application.Features.Admin.ItemTypeSports;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSports
{
    public partial class ItemTypeSports : ComponentBase
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
        private ItemTypeSportsViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeSportViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeSports());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Sport");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeSports.Single(ItemTypeSport => ItemTypeSport.Id == id);
            var viewModel = new SaveItemTypeSportViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeSport(viewModel));

            _viewModel.ItemTypeSports.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeSportViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
