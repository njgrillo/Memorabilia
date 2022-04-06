namespace Memorabilia.Application.Features.Admin.People
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

        private int _sportLeagueLevelId;

        public int FranchiseId { get; set; }

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

        public Domain.Constants.Franchise[] Franchises { get; set; } = Domain.Constants.Franchise.All;

        public int? InductionYear { get; set; }

        public int PersonId { get; set; }

        public int SportLeagueLevelId
        {
            get
            {
                return _sportLeagueLevelId;
            }
            set
            {
                _sportLeagueLevelId = value;
                Franchises = Domain.Constants.Franchise.GetFranchises(Domain.Constants.SportLeagueLevel.Find(value));
            }
        }

        public string SportName => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

        public decimal? VotePercentage { get; set; }
    }
}
