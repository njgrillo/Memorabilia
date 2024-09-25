namespace Memorabilia.Domain.Entities;

public class SingleSeasonRecord : Entity
{
    public SingleSeasonRecord() { }

    public SingleSeasonRecord(int recordTypeId)
    {
        Person = new Person();
        RecordTypeId = recordTypeId;
    }

    public SingleSeasonRecord(int personId, int recordTypeId, int year, string record)
    {
        Person = new Person() { Id = personId };
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
        Year = year;       
    }    

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string Record { get; private set; }

    public int RecordTypeId { get; private set; }

    public int Year { get; private set; }

    public void Set(int recordTypeId, int year, string record)
    {
        Record = record;
        RecordTypeId = recordTypeId;
        Year = year;
    }

    public void SetByPerson(int personId, int year, string record)
    {
        PersonId = personId;
        Record = record;
        Year = year;
    }
}
