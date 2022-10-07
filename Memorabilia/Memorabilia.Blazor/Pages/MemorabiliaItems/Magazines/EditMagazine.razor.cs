#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Magazines
{
    public partial class EditMagazine : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveMagazineViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetMagazine.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveMagazineViewModel(viewModel);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveMagazine.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }

        private void SetDefaults()
        {
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Standard.Id;
        }
    }
}
