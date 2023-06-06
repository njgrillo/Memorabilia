namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SingleSeasonRecordProfileModel
{
    private readonly Entity.SingleSeasonRecord _record;

    public SingleSeasonRecordProfileModel(Entity.SingleSeasonRecord record)
    {
        _record = record;
    }

    public string Record 
        => _record.Record;

    public Constant.RecordType RecordType 
        => Constant.RecordType.Find(RecordTypeId);

    public string RecordTypeAbbreviatedName 
        => RecordType?.ToString();

    public int RecordTypeId
        => _record.RecordTypeId;

    public string RecordTypeName 
        => RecordType?.Name;

    public int Year
        => _record.Year;

    public override string ToString()
        => $"{Year} {Record} {RecordTypeAbbreviatedName}";
}
