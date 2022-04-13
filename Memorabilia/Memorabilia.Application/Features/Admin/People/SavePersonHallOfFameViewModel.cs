namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonHallOfFameViewModel : SaveViewModel
    {
        public SavePersonHallOfFameViewModel() { }

        public SavePersonHallOfFameViewModel(PersonHallOfFameViewModel hallOfFame)
        {            
            Id = hallOfFame.Id;
            InductionYear = hallOfFame.InductionYear;
            PersonId = hallOfFame.PersonId;
            SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
            VotePercentage = hallOfFame.VotePercentage;
        }

        public int? InductionYear { get; set; }

        public int PersonId { get; set; }

        public int SportLeagueLevelId { get; set; }

        public string SportName => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

        public decimal? VotePercentage { get; set; }
    }
}
