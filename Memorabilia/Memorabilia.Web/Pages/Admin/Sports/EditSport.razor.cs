using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.Sports;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Sports
{
    public partial class EditSport : ComponentBase
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

        private SaveSportViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveSport.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveSportViewModel(await QueryRouter.Send(new GetSport.Query(Id)).ConfigureAwait(false));
        }
    }
}
