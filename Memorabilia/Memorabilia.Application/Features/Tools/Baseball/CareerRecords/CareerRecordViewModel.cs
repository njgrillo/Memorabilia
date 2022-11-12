using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.CareerRecords;

public class CareerRecordViewModel
{
    private readonly CareerRecord _careerRecord;

    public CareerRecordViewModel(CareerRecord careerRecord)
    {
        _careerRecord = careerRecord;
    }     

    public int CareerRecordTypeId => _careerRecord.RecordTypeId;

    public string CareerRecordTypeName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.Name;

    public int PersonId => _careerRecord.PersonId;

    public string PersonImageFileName => _careerRecord.Person.ImageFileName;

    public string PersonName => _careerRecord.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Record => _careerRecord.Record;
}
