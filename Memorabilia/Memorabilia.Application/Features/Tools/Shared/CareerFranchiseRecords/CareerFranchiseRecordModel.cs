namespace Memorabilia.Application.Features.Tools.Shared.CareerFranchiseRecords;

public class CareerFranchiseRecordModel : PersonSportToolModel
{
    private readonly Entity.CareerFranchiseRecord _careerFranchiseRecord;

    public CareerFranchiseRecordModel(Entity.CareerFranchiseRecord careerFranchiseRecord, Constant.Sport sport)
    {
        _careerFranchiseRecord = careerFranchiseRecord;
        Sport = sport;
    }

    public int CareerFranchiseRecordTypeId
        => _careerFranchiseRecord.RecordTypeId;

    public string CareerFranchiseRecordTypeName
        => Constant.RecordType.Find(CareerFranchiseRecordTypeId)?.Name;

    public override int PersonId
        => _careerFranchiseRecord.PersonId;

    public override string PersonImageFileName
        => _careerFranchiseRecord.Person.ImageFileName;

    public override string PersonName
        => _careerFranchiseRecord.Person.ProfileName;

    public string Record
        => _careerFranchiseRecord.Record;
}
