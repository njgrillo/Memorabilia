using Demo.Framework.Web;
using Memorabilia.Application.Features.Tools.Profile;
using Memorabilia.Application.Features.Tools.Profile.Baseball;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Tools.Profile
{
    public partial class BaseballProfile : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }        

        public bool DisplayAccomplishments => _selectedAccomplishment?.Text == "Accomplishment";

        public bool DisplayAllStars => _selectedAccomplishment?.Text == "AllStar";

        public bool DisplayAwards => _selectedAccomplishment?.Text == "Award";

        public bool DisplayChampionships => _selectedAccomplishment?.Text == "Championship";

        public bool DisplayLeaders => _selectedAccomplishment?.Text == "Leader";

        private MudBlazor.MudChip _selectedAccomplishment;
        private BaseballProfileViewModel _viewModel = new();

        protected override async Task OnInitializedAsync()
        {
            _viewModel = await QueryRouter.Send(new GetBaseballProfile.Query(PersonId)).ConfigureAwait(false);
        }
    }
}
