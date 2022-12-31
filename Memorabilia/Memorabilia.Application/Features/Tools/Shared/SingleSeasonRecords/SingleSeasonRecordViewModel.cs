using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public class SingleSeasonRecordViewModel : PersonSportToolViewModel
{
    private readonly SingleSeasonRecord _singleSeasonRecord;

    public SingleSeasonRecordViewModel(SingleSeasonRecord singleSeasonRecord, Domain.Constants.Sport sport)
    {
        _singleSeasonRecord = singleSeasonRecord;
        Sport = sport;
    }      

    public override int PersonId => _singleSeasonRecord.PersonId;

    public override string PersonImageFileName => _singleSeasonRecord.Person.ImageFileName;

    public override string PersonName => _singleSeasonRecord.Person.DisplayName;

    public string Record => _singleSeasonRecord.Record;

    public int SingleSeasonRecordTypeId => _singleSeasonRecord.RecordTypeId;

    public string SingleSeasonRecordTypeName => Domain.Constants.RecordType.Find(SingleSeasonRecordTypeId)?.Name;
}
