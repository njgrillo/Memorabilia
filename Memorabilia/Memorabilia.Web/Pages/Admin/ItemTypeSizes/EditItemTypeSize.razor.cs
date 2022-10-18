using Memorabilia.Application.Features.Admin.ItemTypeSizes;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSizes
{
    public partial class EditItemTypeSize : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeSizeViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeSize(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeSizeViewModel(await QueryRouter.Send(new GetItemTypeSize(Id)));
        }
    }
}
