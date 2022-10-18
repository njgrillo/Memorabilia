using Memorabilia.Application.Features.Admin.ItemTypeSpots;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSpots
{
    public partial class EditItemTypeSpots : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeSpotViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeSpot(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeSpotViewModel(await QueryRouter.Send(new GetItemTypeSpot(Id)));
        }
    }
}
