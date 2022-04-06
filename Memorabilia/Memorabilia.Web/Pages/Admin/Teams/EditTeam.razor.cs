using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.Teams;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class EditTeam : ComponentBase
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

        private SaveTeamViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveTeamViewModel(await QueryRouter.Send(new GetTeam.Query(Id)).ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            var command = new SaveTeam.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            _viewModel.Id = command.Id;
        }
    }
}
