using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.SingleSeasonRecords;

public class SingleSeasonRecordViewModel
{
    private readonly SingleSeasonRecord _singleSeasonRecord;

    public SingleSeasonRecordViewModel(SingleSeasonRecord singleSeasonRecord)
    {
        _singleSeasonRecord = singleSeasonRecord;
    }      

    public int PersonId => _singleSeasonRecord.PersonId;

    public string PersonImageFileName => _singleSeasonRecord.Person.ImageFileName;

    public string PersonName => _singleSeasonRecord.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Record => _singleSeasonRecord.Record;

    public int SingleSeasonRecordTypeId => _singleSeasonRecord.RecordTypeId;

    public string SingleSeasonRecordTypeName => Domain.Constants.RecordType.Find(SingleSeasonRecordTypeId)?.Name;
}
