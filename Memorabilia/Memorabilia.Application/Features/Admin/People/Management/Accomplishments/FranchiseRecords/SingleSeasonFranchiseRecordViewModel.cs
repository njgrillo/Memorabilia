namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

public class SingleSeasonFranchiseRecordViewModel
{
    private readonly Entity.SingleSeasonFranchiseRecord _singleSeasonFranchiseRecord;

    public SingleSeasonFranchiseRecordViewModel() { }

    public SingleSeasonFranchiseRecordViewModel(Entity.SingleSeasonFranchiseRecord singleSeasonFranchiseRecord)
    {
        _singleSeasonFranchiseRecord = singleSeasonFranchiseRecord;
    }

    public int singleSeasonFranchiseRecordId
        => _singleSeasonFranchiseRecord.Id;

    public int FranchiseId
        => _singleSeasonFranchiseRecord.FranchiseId;

    public int PersonId
        => _singleSeasonFranchiseRecord.PersonId;

    public string Record
        => _singleSeasonFranchiseRecord.Record;

    public int RecordTypeId
        => _singleSeasonFranchiseRecord.RecordTypeId;

    public string RecordTypeName
        => Constant.RecordType.Find(_singleSeasonFranchiseRecord.RecordTypeId)?.Name;

    public int Year
        => _singleSeasonFranchiseRecord.Year;
}
