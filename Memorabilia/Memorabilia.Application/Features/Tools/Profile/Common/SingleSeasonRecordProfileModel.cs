namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SingleSeasonRecordProfileModel(Entity.SingleSeasonRecord record)
{
    public string Record 
        => record.Record;

    public Constant.RecordType RecordType 
        => Constant.RecordType.Find(RecordTypeId);

    public string RecordTypeAbbreviatedName 
        => RecordType?.ToString();

    public int RecordTypeId
        => record.RecordTypeId;

    public string RecordTypeName 
        => RecordType?.Name;

    public int Year
        => record.Year;

    public override string ToString()
        => $"{Year} {Record} {RecordTypeAbbreviatedName}";
}
