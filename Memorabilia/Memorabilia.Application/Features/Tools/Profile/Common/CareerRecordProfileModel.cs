namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CareerRecordProfileModel
{
    private readonly Entity.CareerRecord _record;

    public CareerRecordProfileModel(Entity.CareerRecord record)
    {
        _record = record;
    }    

    public Constant.RecordType CareerRecordType 
        => Constant.RecordType.Find(CareerRecordTypeId);

    public string CareerRecordTypeAbbreviatedName 
        => CareerRecordType?.ToString();

    public int CareerRecordTypeId 
        => _record.RecordTypeId;

    public string CareerRecordTypeName 
        => CareerRecordType?.Name;

    public string Record 
        => _record.Record;

    public override string ToString()
    {
        return $"{Record} {CareerRecordTypeAbbreviatedName}";
    }
}
