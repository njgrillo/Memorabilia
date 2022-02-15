namespace Memorabilia.Domain.Entities
{
    public class HallOfFame : Framework.Domain.Entity.DomainEntity
    {
        public HallOfFame() { }

        public HallOfFame(int? inductionYear, int personId, int sportId, int levelTypeId, int? franchiseId, int? voteCount)
        {
            InductionYear = inductionYear;
            PersonId = personId;
            SportId = sportId;
            LevelTypeId = levelTypeId;
            FranchiseId = franchiseId;
            VoteCount = voteCount;
        }

        public int? FranchiseId { get; private set; }

        public int? InductionYear { get; private set; }

        public int LevelTypeId { get; private set; }

        public int PersonId { get; private set; }

        public int SportId { get; private set; }

        public int? VoteCount { get; private set; }

        public void Set(int? inductionYear, int sportId, int levelTypeId, int? franchiseId, int? voteCount)
        {
            InductionYear = inductionYear;
            SportId = sportId;
            LevelTypeId = levelTypeId;
            FranchiseId = franchiseId;
            VoteCount = voteCount;
        }
    }
}
