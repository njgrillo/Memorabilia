namespace Memorabilia.Domain.Entities;

public class CareerRecord : Entity
{
    public CareerRecord() { }

    public CareerRecord(int recordTypeId)
    {
        Person = new Person();
        RecordTypeId = recordTypeId;
    }

    public CareerRecord(int personId, int recordTypeId, string record)
    {
        Person = new Person { Id = personId };
        PersonId = personId;
        Record = record;
        RecordTypeId = recordTypeId;
    }    

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string Record { get; private set; }

    public int RecordTypeId { get; private set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public void Set(int recordTypeId, string record)
    {
        RecordTypeId = recordTypeId;
        Record = record;
    }

    public void SetByPerson(int personId, string record)
    {
        PersonId = personId;
        Record = record;
    }
}
