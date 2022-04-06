using Demo.Framework.Web;
using Memorabilia.Application.Features.User.Register;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.User
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private readonly SaveUserViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            var command = new AddUser.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            await LocalStorage.SetAsync("UserId", command.Id).ConfigureAwait(false);

            NavigationManager.NavigateTo("Home");
        }
    }
}
