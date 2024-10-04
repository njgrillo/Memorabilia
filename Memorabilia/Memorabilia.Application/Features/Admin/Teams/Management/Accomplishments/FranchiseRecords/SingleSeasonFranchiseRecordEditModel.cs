namespace Memorabilia.Application.Features.Admin.Teams.Management.Accomplishments.FranchiseRecords;

public class SingleSeasonFranchiseRecordEditModel : EditModel
{
    public SingleSeasonFranchiseRecordEditModel() { }

    public SingleSeasonFranchiseRecordEditModel(Entity.SingleSeasonFranchiseRecord singleSeasonFranchiseRecord)
    {
        FranchiseId = singleSeasonFranchiseRecord.FranchiseId;
        Id = singleSeasonFranchiseRecord.Id;
        Person = new PersonModel(singleSeasonFranchiseRecord.Person);
        PersonId = singleSeasonFranchiseRecord.PersonId;
        Record = singleSeasonFranchiseRecord.Record;
        RecordTypeId = singleSeasonFranchiseRecord.RecordTypeId;
        Year = singleSeasonFranchiseRecord.Year;
    }

    public SingleSeasonFranchiseRecordEditModel(int franchiseId, int recordTypeId, string record = null, Guid? temporaryId = null)
    {
        FranchiseId = franchiseId;
        RecordTypeId = recordTypeId;
        Record = record;
        TemporaryId = temporaryId;
    }

    public int FranchiseId { get; set; }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public string Record { get; set; }

    public int RecordTypeId { get; set; }

    public string RecordTypeName
        => Constant.RecordType.Find(RecordTypeId)?.Name;

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }
}
