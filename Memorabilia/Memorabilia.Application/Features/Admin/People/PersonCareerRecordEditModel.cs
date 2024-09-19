namespace Memorabilia.Application.Features.Admin.People;

public class PersonCareerRecordEditModel : EditModel
{
    public PersonCareerRecordEditModel() { }

    public PersonCareerRecordEditModel(Entity.CareerRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Constant.RecordType.Find(record.RecordTypeId);
    }    

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName 
        => RecordType?.Name;

    public bool Search(string search)
        => search.IsNullOrEmpty() ||
           Record.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           RecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);

    public void Update(string record, Constant.RecordType recordType = null)
    {
        Record = record;

        if (recordType is null)
            return;

        RecordType = recordType;        
    }
}
