#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Helmets
{
    public partial class EditHelmet : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveHelmetViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetHelmet.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveHelmetViewModel(viewModel);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveHelmet.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.Riddell.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
        }
    }
}
