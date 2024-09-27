namespace Memorabilia.Domain.Entities;

public class SingleSeasonFranchiseRecord : Entity
{
    public SingleSeasonFranchiseRecord() { }

    public SingleSeasonFranchiseRecord(int personId, int recordTypeId, int franchiseId, int year, string record)
    {
        
        FranchiseId = franchiseId;
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
        Year = year;
    }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string Record { get; private set; }

    public int RecordTypeId { get; private set; }

    public int Year { get; private set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public void Set(string record)
    {
        Record = record;
    }

    public void Set(int personId, string record, int recordTypeId, int year)
    {
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
        Year = year;
    }
}
