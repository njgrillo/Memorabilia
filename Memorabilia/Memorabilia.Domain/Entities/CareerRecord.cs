namespace Memorabilia.Domain.Entities;

public class CareerRecord : Framework.Library.Domain.Entity.DomainEntity
{
    public CareerRecord() { }

    public CareerRecord(int personId, int recordTypeId, string record)
    {
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
    }    

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string Record { get; private set; }

    public int RecordTypeId { get; private set; }

    public void Set(int recordTypeId, string record)
    {
        RecordTypeId = recordTypeId;
        Record = record;
    }
}
