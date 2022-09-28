#nullable disable

namespace Memorabilia.Blazor.Pages.User
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private readonly SaveUserViewModel _viewModel = new();

        protected async Task HandleValidSubmit()
        {
            var command = new AddUser.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            await LocalStorage.SetAsync("UserId", command.Id).ConfigureAwait(false);

            NavigationManager.NavigateTo("Home");
        }
    }
}
