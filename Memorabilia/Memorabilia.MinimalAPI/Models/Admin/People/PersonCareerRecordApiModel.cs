namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonCareerRecordApiModel
{
    private readonly Entity.CareerRecord _careerRecord;

    public PersonCareerRecordApiModel(Entity.CareerRecord careerRecord)
    {
        _careerRecord = careerRecord;
    }

    public string Name
        => Constant.RecordType.Find(_careerRecord.RecordTypeId).Name;

    public string Record
        => _careerRecord.Record;
}
