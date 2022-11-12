using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CareerRecordProfileViewModel
{
    private readonly CareerRecord _record;

    public CareerRecordProfileViewModel(CareerRecord record)
    {
        _record = record;
    }    

    public Domain.Constants.RecordType CareerRecordType => Domain.Constants.RecordType.Find(CareerRecordTypeId);

    public string CareerRecordTypeAbbreviatedName => CareerRecordType?.ToString();

    public int CareerRecordTypeId => _record.RecordTypeId;

    public string CareerRecordTypeName => CareerRecordType?.Name;

    public string Record => _record.Record;

    public override string ToString()
    {
        return $"{Record} {CareerRecordTypeAbbreviatedName}";
    }
}
