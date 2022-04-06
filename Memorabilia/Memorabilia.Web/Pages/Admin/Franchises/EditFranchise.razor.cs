using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.Franchises;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Franchises
{
    public partial class EditFranchise : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displaySportLeageLevel;
        private SaveFranchiseViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveFranchise.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displaySportLeageLevel = true;
                return;
            }

            _viewModel = new SaveFranchiseViewModel(await QueryRouter.Send(new GetFranchise.Query(Id)).ConfigureAwait(false));
        }
    }
}
