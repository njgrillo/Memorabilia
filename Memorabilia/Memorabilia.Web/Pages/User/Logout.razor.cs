using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.User
{
    public partial class Logout : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task OnLoad()
        {
            await LocalStorage.DeleteAsync("UserId").ConfigureAwait(false);

            NavigationManager.NavigateTo("Login");
        }
    }
}
