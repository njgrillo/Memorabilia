namespace Memorabilia.Domain.Entities;

public class HallOfFame : Framework.Library.Domain.Entity.DomainEntity
{
    public HallOfFame() { }

    public HallOfFame(int? inductionYear, int personId, int sportLeagueLevelId, decimal? votePercentage, int? ballotNumber)
    {
        InductionYear = inductionYear;
        PersonId = personId;
        SportLeagueLevelId = sportLeagueLevelId;
        VotePercentage = votePercentage;
        BallotNumber = ballotNumber;
    }

    public int? BallotNumber { get; private set; }

    public int? InductionYear { get; private set; }

    public int PersonId { get; private set; }

    public int SportLeagueLevelId { get; private set; }

    public decimal? VotePercentage { get; private set; }

    public void Set(int? inductionYear, int sportLeagueLevelId, decimal? votePercentage, int? ballotNumber)
    {
        InductionYear = inductionYear;
        SportLeagueLevelId = sportLeagueLevelId;
        VotePercentage = votePercentage;
        BallotNumber = ballotNumber;
    }
}
