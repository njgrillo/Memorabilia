#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs
{
    public partial class EditBasketball : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private CommissionerViewModel[] _commissioners;
        private SaveBasketballViewModel _viewModel = new ();    

        protected async Task OnLoad()
        {      
            await LoadCommissioners().ConfigureAwait(false);

            var viewModel = await QueryRouter.Send(new GetBasketball.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }    

            _viewModel = new SaveBasketballViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }    

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBasketball.Command(_viewModel)).ConfigureAwait(false);
        }

        private async Task LoadCommissioners()
        {
            _commissioners = (await QueryRouter.Send(new GetCommissioners.Query(_viewModel.SportLeagueLevel.Id)).ConfigureAwait(false)).Commissioners.ToArray();
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
            _viewModel.BasketballTypeId = BasketballType.Official.Id;
            _viewModel.BrandId = Brand.Spalding.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;        
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Domain.Constants.Size.Standard.Id;       
        }
    }
}
