using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCareerRecordViewModel : SaveViewModel
{
    public SavePersonCareerRecordViewModel() { }

    public SavePersonCareerRecordViewModel(CareerRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Domain.Constants.RecordType.Find(record.RecordTypeId);
    }    

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Domain.Constants.RecordType RecordType { get; set; }

    public string RecordTypeName => RecordType?.Name;
}
