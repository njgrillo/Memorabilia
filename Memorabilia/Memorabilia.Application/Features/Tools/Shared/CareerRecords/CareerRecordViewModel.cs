using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordViewModel : PersonSportToolViewModel
{
    private readonly CareerRecord _careerRecord;

    public CareerRecordViewModel(CareerRecord careerRecord, Domain.Constants.Sport sport)
    {
        _careerRecord = careerRecord;
        Sport = sport;
    }     

    public int CareerRecordTypeId => _careerRecord.RecordTypeId;

    public string CareerRecordTypeName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.Name;

    public override int PersonId => _careerRecord.PersonId;

    public override string PersonImageFileName => _careerRecord.Person.ImageFileName;

    public override string PersonName => _careerRecord.Person.DisplayName;

    public string Record => _careerRecord.Record;
}
