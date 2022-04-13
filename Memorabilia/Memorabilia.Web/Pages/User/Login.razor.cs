using Demo.Framework.Web;
using Memorabilia.Application.Features.User;
using Memorabilia.Application.Features.User.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.User
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private readonly LoginUserViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            var viewModel = await QueryRouter.Send(new GetUser.Query(_viewModel.Username, _viewModel.Password)).ConfigureAwait(false);

            if (!viewModel.IsValid || viewModel.Id == 0)
            {
                //TODO: Didn't find user

                return;
            }

            await LocalStorage.SetAsync("UserId", viewModel.Id).ConfigureAwait(false);

            NavigationManager.NavigateTo("Home");
        }

        protected void OnLoad()
        {
            //NavigationManager.NavigateTo("Home");
        }
    }
}
