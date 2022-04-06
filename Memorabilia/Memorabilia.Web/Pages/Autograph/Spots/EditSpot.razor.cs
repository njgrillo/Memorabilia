using Demo.Framework.Web;
using Memorabilia.Application.Features.Autograph.Spot;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Autograph.Spots
{
    public partial class EditSpot : ComponentBase
    {
        [Parameter]
        public int AutographId { get; set; }

        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveSpotViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            _viewModel = new SaveSpotViewModel(await QueryRouter.Send(new GetSpot.Query(AutographId)).ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveSpot.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
