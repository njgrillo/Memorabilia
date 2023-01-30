namespace Memorabilia.Blazor.Pages.MemorabiliaItems
{
    public partial class MemorabiliaEditor : ImagePage
    {   
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

            _viewModel.ContinueNavigationPath = $"Memorabilia/{_viewModel.ItemTypeName.Replace(" ", "")}/Edit/{command.Id}";
        }
    }
}
