namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Records;

public class SingleSeasonRecordEditModel : EditModel
{
    public SingleSeasonRecordEditModel() { }

    public SingleSeasonRecordEditModel(Entity.SingleSeasonRecord singleSeasonRecord)
    {
        Id = singleSeasonRecord.Id;
        Person = new PersonModel(singleSeasonRecord.Person);
        Record = singleSeasonRecord.Record;
        RecordTypeId = singleSeasonRecord.RecordTypeId;
        Year = singleSeasonRecord.Year > 0 ? singleSeasonRecord.Year : null;
    }

    public SingleSeasonRecordEditModel(int personId, int recordTypeId, string record, int? year)
    {
        PersonId = personId;
        RecordTypeId = recordTypeId;
        Record = record;
        TemporaryId = Guid.NewGuid();
        Year = year;
    }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public string Record { get; set; }

    public int RecordTypeId { get; set; }

    public string RecordTypeName
        => Constant.RecordType.Find(RecordTypeId)?.Name;

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }
}
