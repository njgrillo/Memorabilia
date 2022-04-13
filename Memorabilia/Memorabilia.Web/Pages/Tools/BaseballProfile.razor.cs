using Demo.Framework.Web;
using Memorabilia.Application.Features.Tools.Profile;
using Memorabilia.Application.Features.Tools.Profile.Baseball;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Tools
{
    public partial class BaseballProfile : ComponentBase
    {
        [Parameter]
        public int PersonId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private BaseballProfileViewModel _viewModel = new();

        protected override async Task OnInitializedAsync()
        {
            _viewModel = await QueryRouter.Send(new GetBaseballProfile.Query(PersonId)).ConfigureAwait(false);
        }
    }
}
