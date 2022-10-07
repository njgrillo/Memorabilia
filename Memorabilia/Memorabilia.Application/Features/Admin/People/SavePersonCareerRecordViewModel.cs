using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCareerRecordViewModel : SaveViewModel
{
    public SavePersonCareerRecordViewModel() { }

    public SavePersonCareerRecordViewModel(CareerRecord record)
    {
        Amount = record.Amount;
        Id = record.Id;
        PersonId = record.PersonId;
        RecordTypeId = record.RecordTypeId;
    }

    public decimal? Amount { get; set; }

    public string DisplayAmount => Amount?.ToString("G29");

    public int PersonId { get; set; }

    public int RecordTypeId { get; set; }

    public string RecordTypeName => Domain.Constants.RecordType.Find(RecordTypeId)?.Name;

    public Domain.Constants.RecordType[] RecordTypes => Domain.Constants.RecordType.All;
}
