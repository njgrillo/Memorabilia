using Demo.Framework.Web;
using Memorabilia.Application.Features.Tools.Baseball.Accomplishments;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Tools.Baseball
{
    public partial class Accomplishments : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AccomplishmentsViewModel _viewModel = new();

        private async Task OnInputChange(int accomplishmentTypeId)
        {
            _viewModel = await QueryRouter.Send(new GetAccomplishments.Query(accomplishmentTypeId)).ConfigureAwait(false);
        }
    }
}
