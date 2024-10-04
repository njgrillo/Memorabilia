namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonFranchiseRecords;

public class SingleSeasonFranchiseRecordModel : PersonSportToolModel
{
    private readonly Entity.SingleSeasonFranchiseRecord _singleSeasonFranchiseRecord;

    public SingleSeasonFranchiseRecordModel(Entity.SingleSeasonFranchiseRecord singleSeasonFranchiseRecord, Constant.Sport sport)
    {
        _singleSeasonFranchiseRecord = singleSeasonFranchiseRecord;
        Sport = sport;
    }

    public override int PersonId
        => _singleSeasonFranchiseRecord.PersonId;

    public override string PersonImageFileName
        => _singleSeasonFranchiseRecord.Person.ImageFileName;

    public override string PersonName
        => _singleSeasonFranchiseRecord.Person.ProfileName;

    public string Record
        => _singleSeasonFranchiseRecord.Record;

    public int SingleSeasonRecordTypeId
        => _singleSeasonFranchiseRecord.RecordTypeId;

    public string SingleSeasonRecordTypeName
        => Constant.RecordType.Find(SingleSeasonRecordTypeId)?.Name;

    public int Year
        => _singleSeasonFranchiseRecord.Year;
}
