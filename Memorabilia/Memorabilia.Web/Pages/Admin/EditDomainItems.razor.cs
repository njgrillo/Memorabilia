using Memorabilia.Application.Features.Admin;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin
{
    public partial class EditDomainItems : ComponentBase
    {
        private readonly AdminDomainItemsViewModel _viewModel = new ();

        public async Task OnLoad() { }
    }
}
