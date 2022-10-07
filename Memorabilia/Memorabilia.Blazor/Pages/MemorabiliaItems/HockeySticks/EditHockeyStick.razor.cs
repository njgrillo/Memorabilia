#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HockeySticks
{
    public partial class EditHockeyStick : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveHockeyStickViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetHockeyStick.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveHockeyStickViewModel(viewModel);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveHockeyStick.Command(_viewModel)).ConfigureAwait(false);
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
            _viewModel.BrandId = Brand.CCM.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Full.Id;
        }
    }
}
