#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems
{
    public partial class MemorabiliaEditor : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }        

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }        

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public int UserId { get; set; }

        private SaveMemorabiliaItemViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveMemorabiliaItemViewModel(await QueryRouter.Send(new GetMemorabiliaItem(Id)));
        }

        protected async Task OnSave()
        {    
            if (UserId == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel.UserId = UserId;

            var command = new SaveMemorabiliaItem.Command(_viewModel);

            await CommandRouter.Send(command);

            var itemTypeName = ItemType.Find(_viewModel.ItemTypeId).Name;
            _viewModel.ContinueNavigationPath = $"Memorabilia/{itemTypeName.Replace(" ", "")}/Edit/{command.Id}";
        }
    }
}
