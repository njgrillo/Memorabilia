#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats
{
    public partial class EditBat : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveBatViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetBat.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveBatViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBat.Command(_viewModel)).ConfigureAwait(false);
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
            _viewModel.BatTypeId = BatType.BigStick.Id;
            _viewModel.BrandId = Brand.Rawlings.Id;
            _viewModel.ColorId = Domain.Constants.Color.Black.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Full.Id;
        }
    }
}
