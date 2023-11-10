namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public class SingleSeasonRecordModel : PersonSportToolModel
{
    private readonly Entity.SingleSeasonRecord _singleSeasonRecord;

    public SingleSeasonRecordModel(Entity.SingleSeasonRecord singleSeasonRecord, Constant.Sport sport)
    {
        _singleSeasonRecord = singleSeasonRecord;
        Sport = sport;
    }      

    public override int PersonId 
        => _singleSeasonRecord.PersonId;

    public override string PersonImageFileName 
        => _singleSeasonRecord.Person.ImageFileName;

    public override string PersonName 
        => _singleSeasonRecord.Person.ProfileName;

    public string Record 
        => _singleSeasonRecord.Record;

    public int SingleSeasonRecordTypeId 
        => _singleSeasonRecord.RecordTypeId;

    public string SingleSeasonRecordTypeName 
        => Constant.RecordType.Find(SingleSeasonRecordTypeId)?.Name;
}
