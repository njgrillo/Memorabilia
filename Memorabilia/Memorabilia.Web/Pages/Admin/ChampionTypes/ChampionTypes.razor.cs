using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.ChampionTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ChampionTypes
{
    public partial class ChampionTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private ChampionTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveChampionType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetChampionTypes.Query()).ConfigureAwait(false);
        }
    }
}
