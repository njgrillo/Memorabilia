namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonSingleSeasonRecordApiModel
{
    private readonly Entity.SingleSeasonRecord _singleSeasonRecord;

    public PersonSingleSeasonRecordApiModel(Entity.SingleSeasonRecord singleSeasonRecord)
    {
        _singleSeasonRecord = singleSeasonRecord;
    }

    public string Name
        => Constant.RecordType.Find(_singleSeasonRecord.RecordTypeId).Name;

    public string Record
        => _singleSeasonRecord.Record;
}
