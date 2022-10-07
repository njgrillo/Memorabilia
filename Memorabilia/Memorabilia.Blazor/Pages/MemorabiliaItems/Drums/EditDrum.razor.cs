#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Drums
{
    public partial class EditDrum : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveDrumViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetDrum.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveDrumViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveDrum.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.Muslady.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
        }
    }
}
