using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonAccolade : ComponentBase
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
        public int PersonId { get; set; }

        private SavePersonAccoladeViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonAccoladeViewModel(PersonId, await QueryRouter.Send(new GetPersonAccomplishments.Query(PersonId)));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonAccolades.Command(PersonId, _viewModel)).ConfigureAwait(false);
        }
    }
}
