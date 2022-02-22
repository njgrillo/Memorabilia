namespace Memorabilia.Application.Features.Admin.Person
{
    public class PersonHallOfFameViewModel
    {
        private readonly Domain.Entities.HallOfFame _personHallOfFame;

        public PersonHallOfFameViewModel() { }

        public PersonHallOfFameViewModel(Domain.Entities.HallOfFame personHallOfFame)
        {
            _personHallOfFame = personHallOfFame;
        }

        public int? FranchiseId => _personHallOfFame.FranchiseId;

        public int Id => _personHallOfFame.Id;

        public int? InductionYear => _personHallOfFame.InductionYear;

        public int PersonId => _personHallOfFame.PersonId;

        public int SportLeagueLevelId => _personHallOfFame.SportLeagueLevelId;

        public decimal? VotePercentage => _personHallOfFame.VotePercentage;
    }
}
