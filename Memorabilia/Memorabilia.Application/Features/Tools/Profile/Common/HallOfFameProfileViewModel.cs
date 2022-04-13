using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class HallOfFameProfileViewModel
    {
        private readonly HallOfFame _hallOfFame;

        public HallOfFameProfileViewModel(HallOfFame hallOfFame)
        {
            _hallOfFame = hallOfFame;
        }

        public int? InductionYear => _hallOfFame.InductionYear;

        public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.Find(_hallOfFame.SportLeagueLevelId);

        public decimal? VotePercentage => _hallOfFame.VotePercentage;
    }
}
