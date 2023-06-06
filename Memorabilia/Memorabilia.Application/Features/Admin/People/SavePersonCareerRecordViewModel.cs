using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCareerRecordViewModel : EditModel
{
    public SavePersonCareerRecordViewModel() { }

    public SavePersonCareerRecordViewModel(CareerRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Constant.RecordType.Find(record.RecordTypeId);
    }    

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName => RecordType?.Name;
}
