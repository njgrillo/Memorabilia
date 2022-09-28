
using Memorabilia.Application.Features.Admin.Commissioners;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Application.Features.Memorabilia.Football;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Footballs
{
    public partial class EditFootball : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private CommissionerViewModel[] _commissioners;
        private SaveFootballViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            await LoadCommissioners().ConfigureAwait(false);

            var viewModel = await QueryRouter.Send(new GetFootball.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveFootballViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveFootball.Command(_viewModel)).ConfigureAwait(false);
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
            _viewModel.BrandId = Brand.Wilson.Id;
            _viewModel.FootballTypeId = FootballType.Duke.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Size.Full.Id;
        }
    }
}
