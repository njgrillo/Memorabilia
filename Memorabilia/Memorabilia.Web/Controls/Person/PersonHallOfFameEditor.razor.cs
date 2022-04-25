using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonHallOfFameEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

        private bool _canAddHallOfFame = true;
        private bool _canEditSportLeagueLevel = true;
        private bool _canUpdateHallOfFame;
        private SavePersonHallOfFameViewModel _viewModel = new();

        private void Add()
        {
            HallOfFames.Add(_viewModel);

            _viewModel = new SavePersonHallOfFameViewModel();
        }

        private void Edit(SavePersonHallOfFameViewModel hallOfFame)
        {
            _viewModel.BallotNumber = hallOfFame.BallotNumber;
            _viewModel.InductionYear = hallOfFame.InductionYear;
            _viewModel.SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
            _viewModel.VotePercentage = hallOfFame.VotePercentage;

            _canAddHallOfFame = false;
            _canEditSportLeagueLevel = false;
            _canUpdateHallOfFame = true;
        }

        private void Remove(int sportLeagueLevelId)
        {
            var hallOfFame = HallOfFames.SingleOrDefault(hallOfFame => hallOfFame.SportLeagueLevelId == sportLeagueLevelId);

            if (hallOfFame == null)
                return;

            hallOfFame.IsDeleted = true;
        }

        private void Update()
        {
            var hallOfFame = HallOfFames.Single(hof => hof.SportLeagueLevelId == _viewModel.SportLeagueLevelId);

            hallOfFame.BallotNumber = _viewModel.BallotNumber;
            hallOfFame.InductionYear = _viewModel.InductionYear;
            hallOfFame.VotePercentage = _viewModel.VotePercentage;            

            _viewModel = new SavePersonHallOfFameViewModel();

            _canAddHallOfFame = true;
            _canEditSportLeagueLevel = true;
            _canUpdateHallOfFame = false;
        }
    }
}
