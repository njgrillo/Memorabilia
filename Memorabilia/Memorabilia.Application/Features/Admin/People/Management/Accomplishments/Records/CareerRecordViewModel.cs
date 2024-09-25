namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

public class CareerRecordViewModel
{
    private readonly Entity.CareerRecord _careerRecord;

    public CareerRecordViewModel() { }

    public CareerRecordViewModel(Entity.CareerRecord careerRecord)
    {
        _careerRecord = careerRecord;
    }

    public int Id
        => _careerRecord.Id;

    public int PersonId
        => _careerRecord.PersonId;

    public string Record
        => _careerRecord.Record;

    public int RecordTypeId
        => _careerRecord.RecordTypeId;

    public string RecordTypeName
        => Constant.RecordType.Find(_careerRecord.RecordTypeId)?.Name;
}
