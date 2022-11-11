using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.SingleSeasonRecords;

public class SingleSeasonRecordViewModel
{
    private readonly SingleSeasonRecord _singleSeasonRecord;

    public SingleSeasonRecordViewModel(SingleSeasonRecord singleSeasonRecord)
    {
        _singleSeasonRecord = singleSeasonRecord;
    }

    public string Amount => string.Format("{0:0,0.###}", _singleSeasonRecord.Amount);    

    public int PersonId => _singleSeasonRecord.PersonId;

    public string PersonImageFileName => _singleSeasonRecord.Person.ImageFileName;

    public string PersonName => _singleSeasonRecord.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public int SingleSeasonRecordTypeId => _singleSeasonRecord.RecordTypeId;

    public string SingleSeasonRecordTypeName => Domain.Constants.RecordType.Find(SingleSeasonRecordTypeId)?.Name;
}
