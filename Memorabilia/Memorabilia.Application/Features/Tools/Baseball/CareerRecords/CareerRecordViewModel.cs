using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.CareerRecords;

public class CareerRecordViewModel
{
    private readonly CareerRecord _careerRecord;

    public CareerRecordViewModel(CareerRecord careerRecord)
    {
        _careerRecord = careerRecord;
    }

    public string Amount => string.Format("{0:0,0.###}", _careerRecord.Amount); 

    public int CareerRecordTypeId => _careerRecord.RecordTypeId;

    public string CareerRecordTypeName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.Name;

    public int PersonId => _careerRecord.PersonId;

    public string PersonImagePath => _careerRecord.Person.ImagePath;

    public string PersonName => _careerRecord.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";    
}
