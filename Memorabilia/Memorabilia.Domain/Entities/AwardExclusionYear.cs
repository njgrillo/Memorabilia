namespace Memorabilia.Domain.Entities;

public class AwardExclusionYear : Framework.Library.Domain.Entity.DomainEntity
{
    public AwardExclusionYear() { }

    public AwardExclusionYear(int awardDetailId, int year, string reason)
    {
        AwardDetailId = awardDetailId;
        Reason = reason;
        Year = year;
    }

    public int AwardDetailId { get; private set; }

    public string Reason { get; private set; }

    public int Year { get; private set; }

    public void Set(int year, string reason)
    {
        Reason = reason;
        Year = year;
    }
}
