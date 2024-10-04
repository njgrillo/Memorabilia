namespace Memorabilia.Application.Features.Admin.Teams.Management.Accomplishments.FranchiseRecords;

public class CareerFranchiseRecordViewModel
{
    private readonly Entity.CareerFranchiseRecord _careerFranchiseRecord;

    public CareerFranchiseRecordViewModel() { }

    public CareerFranchiseRecordViewModel(Entity.CareerFranchiseRecord careerFranchiseRecord)
    {
        _careerFranchiseRecord = careerFranchiseRecord;
    }

    public int CareerFranchiseRecordId
        => _careerFranchiseRecord.Id;

    public int FranchiseId
        => _careerFranchiseRecord.FranchiseId;

    public int PersonId
        => _careerFranchiseRecord.PersonId;

    public string Record
        => _careerFranchiseRecord.Record;

    public int RecordTypeId
        => _careerFranchiseRecord.RecordTypeId;

    public string RecordTypeName
        => Constant.RecordType.Find(_careerFranchiseRecord.RecordTypeId)?.Name;
}
