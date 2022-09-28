
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.TeamRoleTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.TeamRoleTypes
{
    public partial class TeamRoleTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private TeamRoleTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveTeamRoleType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetTeamRoleTypes.Query()).ConfigureAwait(false);
        }
    }
}
