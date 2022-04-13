namespace Memorabilia.Domain.Entities
{
    public class HallOfFame : Framework.Domain.Entity.DomainEntity
    {
        public HallOfFame() { }

        public HallOfFame(int? inductionYear, int personId, int sportLeagueLevelId, decimal? votePercentage)
        {
            InductionYear = inductionYear;
            PersonId = personId;
            SportLeagueLevelId = sportLeagueLevelId;
            VotePercentage = votePercentage;
        }

        public int? InductionYear { get; private set; }

        public int PersonId { get; private set; }

        public int SportLeagueLevelId { get; private set; }

        public decimal? VotePercentage { get; private set; }

        public void Set(int? inductionYear, int sportLeagueLevelId, decimal? votePercentage)
        {
            InductionYear = inductionYear;
            SportLeagueLevelId = sportLeagueLevelId;
            VotePercentage = votePercentage;
        }
    }
}
