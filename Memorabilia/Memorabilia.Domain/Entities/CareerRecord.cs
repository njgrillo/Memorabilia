namespace Memorabilia.Domain.Entities;

public class CareerRecord : Framework.Library.Domain.Entity.DomainEntity
{
    public CareerRecord() { }

    public CareerRecord(int personId, int recordTypeId, decimal? amount)
    {
        PersonId = personId;
        RecordTypeId = recordTypeId;
        Amount = amount;
    }

    public decimal? Amount { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int RecordTypeId { get; private set; }

    public void Set(int recordTypeId, decimal? amount)
    {
        RecordTypeId = recordTypeId;
        Amount = amount;
    }
}
