using Demo.Framework.Web;
using Memorabilia.Application.Features.Tools.Baseball.Awards;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Tools.Baseball
{
    public partial class Awards : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AwardsViewModel _viewModel = new();

        private async Task OnInputChange(int awardTypeId)
        {
            _viewModel = await QueryRouter.Send(new GetAwards.Query(awardTypeId)).ConfigureAwait(false);
        }
    }
}
