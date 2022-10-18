using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

namespace Memorabilia.Web.Pages.Admin.ItemTypeGameStyles
{
    public partial class EditItemTypeGameStyle : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeGameStyleViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeGameStyle(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeGameStyleViewModel(await QueryRouter.Send(new GetItemTypeGameStyle(Id)));
        }
    }
}
