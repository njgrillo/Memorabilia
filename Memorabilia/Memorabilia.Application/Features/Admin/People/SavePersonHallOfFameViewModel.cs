using Memorabilia.Domain.Entities;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonHallOfFameViewModel : SaveViewModel
    {
        public SavePersonHallOfFameViewModel() { }

        public SavePersonHallOfFameViewModel(HallOfFame hallOfFame)
        {            
            BallotNumber = hallOfFame.BallotNumber ?? 0;
            Id = hallOfFame.Id;
            InductionYear = hallOfFame.InductionYear;
            PersonId = hallOfFame.PersonId;
            SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
            VotePercentage = hallOfFame.VotePercentage;
        }

        public int BallotNumber { get; set; }

        public string BallotNumberName => Domain.Constants.BallotNumber.Find(BallotNumber)?.Name;

        public Domain.Constants.BallotNumber[] BallotNumbers => Domain.Constants.BallotNumber.All;

        public int? InductionYear { get; set; }

        public int PersonId { get; set; }

        public int SportLeagueLevelId { get; set; }

        public Domain.Constants.SportLeagueLevel[] SportLeagueLevels => Domain.Constants.SportLeagueLevel.All;

        public string SportName => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

        public decimal? VotePercentage { get; set; }
    }
}
