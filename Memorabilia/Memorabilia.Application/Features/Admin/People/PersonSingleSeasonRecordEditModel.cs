namespace Memorabilia.Application.Features.Admin.People;

public class PersonSingleSeasonRecordEditModel : EditModel
{
    public PersonSingleSeasonRecordEditModel() { }

    public PersonSingleSeasonRecordEditModel(Entity.SingleSeasonRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Constant.RecordType.Find(record.RecordTypeId);
        Year = record.Year;
    }   

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName 
        => RecordType?.Name;

    public int? Year { get; set; }
}
