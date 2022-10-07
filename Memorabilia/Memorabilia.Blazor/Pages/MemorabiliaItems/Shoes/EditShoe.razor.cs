#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shoes
{
    public partial class EditShoe : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveShoeViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetShoe.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveShoeViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveShoe.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }

        private void SelectedTeamChanged(SaveTeamViewModel team)
        {
            _viewModel.Team = team;
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.Nike.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Standard.Id;
        }
    }
}
