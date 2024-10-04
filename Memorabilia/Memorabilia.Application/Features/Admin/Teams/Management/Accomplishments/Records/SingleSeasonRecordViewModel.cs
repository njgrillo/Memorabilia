namespace Memorabilia.Application.Features.Admin.Teams.Management.Accomplishments.Records;

public class SingleSeasonRecordViewModel
{
    private readonly Entity.SingleSeasonRecord _singleSeasonRecord;

    public SingleSeasonRecordViewModel() { }

    public SingleSeasonRecordViewModel(Entity.SingleSeasonRecord singleSeasonRecord)
    {
        _singleSeasonRecord = singleSeasonRecord;
    }

    public int Id
        => _singleSeasonRecord.Id;

    public int PersonId
        => _singleSeasonRecord.PersonId;

    public string Record
        => _singleSeasonRecord.Record;

    public int RecordTypeId
        => _singleSeasonRecord.RecordTypeId;

    public string RecordTypeName
        => Constant.RecordType.Find(_singleSeasonRecord.RecordTypeId)?.Name;

    public int Year
        => _singleSeasonRecord.Year;
}
