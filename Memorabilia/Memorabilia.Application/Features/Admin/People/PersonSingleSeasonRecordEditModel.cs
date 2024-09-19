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

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           Record.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           RecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }

    public void Update(Constant.RecordType recordType, int? year, string record)
    {
        RecordType = recordType;
        Year = year;
        Record = record;
    }
}
