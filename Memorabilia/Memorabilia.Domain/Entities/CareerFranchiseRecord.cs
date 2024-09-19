namespace Memorabilia.Domain.Entities;

public class CareerFranchiseRecord : Entity
{
    public CareerFranchiseRecord() { }

    public CareerFranchiseRecord(int personId, int recordTypeId, int franchiseId, string record)
    {
        FranchiseId = franchiseId;
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
    }    

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }    

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string Record { get; private set; }

    public int RecordTypeId { get; private set; }

    public void Set(string record)
    {
        Record = record;
    }

    public void Set(int personId, string record, int recordTypeId)
    {
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
    }
}
