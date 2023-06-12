namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordModel : PersonSportToolModel
{
    private readonly Entity.CareerRecord _careerRecord;

    public CareerRecordModel(Entity.CareerRecord careerRecord, Constant.Sport sport)
    {
        _careerRecord = careerRecord;
        Sport = sport;
    }     

    public int CareerRecordTypeId 
        => _careerRecord.RecordTypeId;

    public string CareerRecordTypeName 
        => Constant.RecordType.Find(CareerRecordTypeId)?.Name;

    public override int PersonId 
        => _careerRecord.PersonId;

    public override string PersonImageFileName 
        => _careerRecord.Person.ImageFileName;

    public override string PersonName 
        => _careerRecord.Person.DisplayName;

    public string Record 
        => _careerRecord.Record;
}
