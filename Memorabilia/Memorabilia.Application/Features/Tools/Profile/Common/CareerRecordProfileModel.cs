namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CareerRecordProfileModel(Entity.CareerRecord record)
{
    public Constant.RecordType CareerRecordType 
        => Constant.RecordType.Find(CareerRecordTypeId);

    public string CareerRecordTypeAbbreviatedName 
        => CareerRecordType?.ToString();

    public int CareerRecordTypeId 
        => record.RecordTypeId;

    public string CareerRecordTypeName 
        => CareerRecordType?.Name;

    public string Record 
        => record.Record;

    public override string ToString()
        => $"{Record} {CareerRecordTypeAbbreviatedName}";
}
