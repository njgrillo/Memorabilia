namespace Memorabilia.Domain.Entities;

public class SingleSeasonRecord : Framework.Library.Domain.Entity.DomainEntity
{
    public SingleSeasonRecord() { }

    public SingleSeasonRecord(int personId, int recordTypeId, int year, decimal? amount)
    {
        PersonId = personId;
        RecordTypeId = recordTypeId;
        Year = year;
        Amount = amount;
    }

    public decimal? Amount { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int RecordTypeId { get; private set; }

    public int Year { get; private set; }

    public void Set(int recordTypeId, int year, decimal? amount)
    {
        RecordTypeId = recordTypeId;
        Year = year;
        Amount = amount;
    }
}
