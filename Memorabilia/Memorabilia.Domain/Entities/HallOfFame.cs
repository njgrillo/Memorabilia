namespace Memorabilia.Domain.Entities;

public class HallOfFame : Entity
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

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int SportLeagueLevelId { get; private set; }

    [Precision(5, 2)]
    public decimal? VotePercentage { get; private set; }

    public void Set(int? inductionYear, int sportLeagueLevelId, decimal? votePercentage, int? ballotNumber)
    {
        InductionYear = inductionYear;
        SportLeagueLevelId = sportLeagueLevelId;
        VotePercentage = votePercentage;
        BallotNumber = ballotNumber;
    }
}
