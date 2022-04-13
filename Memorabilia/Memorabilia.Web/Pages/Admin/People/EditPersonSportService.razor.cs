using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonSportService : ComponentBase
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

        private SavePersonSportServiceViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonSportServiceViewModel(PersonId, 
                                                             await QueryRouter.Send(new GetPersonSportService.Query(PersonId))
                             .ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonSportService.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
