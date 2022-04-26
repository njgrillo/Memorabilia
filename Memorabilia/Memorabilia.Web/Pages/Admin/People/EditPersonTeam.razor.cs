using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonTeam : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonTeamsViewModel _viewModel = new();        

        protected async Task OnLoad()
        {
            var teams = (await QueryRouter.Send(new GetPersonTeams.Query(PersonId))
                                          .ConfigureAwait(false)).Select(personTeam => new SavePersonTeamViewModel(personTeam))
                                                                 .ToList();

            _viewModel = new SavePersonTeamsViewModel(PersonId, teams);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonTeam.Command(PersonId, _viewModel.Teams)).ConfigureAwait(false);
        }
    }
}
