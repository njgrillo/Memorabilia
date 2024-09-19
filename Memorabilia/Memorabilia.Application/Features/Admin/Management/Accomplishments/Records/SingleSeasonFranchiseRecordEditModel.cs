namespace Memorabilia.Application.Features.Admin.Management.Accomplishments.Records;

public class SingleSeasonFranchiseRecordEditModel : EditModel
{
    public SingleSeasonFranchiseRecordEditModel() { }

    public SingleSeasonFranchiseRecordEditModel(Entity.SingleSeasonFranchiseRecord singleSeasonFranchiseRecord)
    {
        FranchiseId = singleSeasonFranchiseRecord.FranchiseId;
        Person = new PersonModel(singleSeasonFranchiseRecord.Person);
        PersonId = singleSeasonFranchiseRecord.PersonId;
        Record = singleSeasonFranchiseRecord.Record;
        RecordTypeId = singleSeasonFranchiseRecord.RecordTypeId;
        Year = singleSeasonFranchiseRecord.Year;
    }

    public SingleSeasonFranchiseRecordEditModel(int franchiseId, int recordTypeId)
    {
        FranchiseId = franchiseId;
        RecordTypeId = recordTypeId;
    }

    public int FranchiseId { get; set; }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public string Record { get; set; }

    public int RecordTypeId { get; set; }

    public string RecordTypeName
        => Constant.RecordType.Find(RecordTypeId)?.Name;

    public int Year { get; set; }
}
