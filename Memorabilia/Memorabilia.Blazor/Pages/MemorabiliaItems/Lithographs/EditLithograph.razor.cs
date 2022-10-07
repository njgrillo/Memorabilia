#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Lithographs
{
    public partial class EditLithograph : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveLithographViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetLithograph.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveLithographViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveLithograph.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.None.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.OrientationId = Domain.Constants.Orientation.Portrait.Id;
            _viewModel.SizeId = Domain.Constants.Size.EightByTen.Id;
        }
    }
}
