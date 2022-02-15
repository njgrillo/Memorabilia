namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonHallOfFameViewModel : SaveViewModel
    {
        public SavePersonHallOfFameViewModel() { }

        //public SavePersonHallOfFameViewModel(Domain.Entities.HallOfFame occupation)
        //{
        //    Id = occupation.Id;
        //    OccupationId = occupation.OccupationId;
        //    OccupationTypeId = occupation.OccupationTypeId;
        //}

        public int FranchiseId { get; set; }

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

        public int? InductionYear { get; set; }

        public int LevelTypeId { get; set; }

        public string LevelTypeName => Domain.Constants.LevelType.Find(LevelTypeId)?.Name;

        public int PersonId { get; set; }

        public int SportId { get; set; }

        public string SportName => Domain.Constants.Sport.Find(SportId)?.Name;

        public int? VoteCount { get; set; }
    }
}
