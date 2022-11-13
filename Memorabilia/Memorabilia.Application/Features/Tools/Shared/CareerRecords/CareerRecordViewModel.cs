using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordViewModel : PersonSportToolViewModel
{
    private readonly CareerRecord _careerRecord;

    public CareerRecordViewModel(CareerRecord careerRecord, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        _careerRecord = careerRecord;
        SportLeagueLevel = sportLeagueLevel;
    }     

    public int CareerRecordTypeId => _careerRecord.RecordTypeId;

    public string CareerRecordTypeName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.Name;

    public override int PersonId => _careerRecord.PersonId;

    public override string PersonImageFileName => _careerRecord.Person.ImageFileName;

    public override string PersonName => _careerRecord.Person.DisplayName;

    public string Record => _careerRecord.Record;
}
