#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Jerseys
{
    public partial class EditJersey : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveJerseyViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetJersey.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveJerseyViewModel(viewModel);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveJersey.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SetDefaults()
        {
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.JerseyTypeId = JerseyType.Stitched.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
        }
    }
}
