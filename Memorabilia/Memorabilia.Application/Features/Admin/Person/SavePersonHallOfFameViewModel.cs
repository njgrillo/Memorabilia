namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonHallOfFameViewModel : SaveViewModel
    {
        public SavePersonHallOfFameViewModel() { }

        public SavePersonHallOfFameViewModel(PersonHallOfFameViewModel hallOfFame)
        {            
            FranchiseId = hallOfFame.FranchiseId ?? 0;
            Id = hallOfFame.Id;
            InductionYear = hallOfFame.InductionYear;
            PersonId = hallOfFame.PersonId;
            SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
            VotePercentage = hallOfFame.VotePercentage;
        }

        public int FranchiseId { get; set; }

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

        public int? InductionYear { get; set; }

        public int PersonId { get; set; }

        public override string RoutePrefix => "People";

        public int SportLeagueLevelId { get; set; }

        public string SportName => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

        public decimal? VotePercentage { get; set; }
    }
}
