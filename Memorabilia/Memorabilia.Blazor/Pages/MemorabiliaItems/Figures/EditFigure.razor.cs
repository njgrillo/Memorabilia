#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Figures
{
    public partial class EditFigure : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveFigureViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetFigure.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveFigureViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveFigure.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }

        private void SetDefaults()
        {
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Standard.Id;
        }
    }
}
