using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.LeaderTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.LeaderTypes
{
    public partial class LeaderTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private LeaderTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveLeaderType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetLeaderTypes.Query()).ConfigureAwait(false);
        }
    }
}
