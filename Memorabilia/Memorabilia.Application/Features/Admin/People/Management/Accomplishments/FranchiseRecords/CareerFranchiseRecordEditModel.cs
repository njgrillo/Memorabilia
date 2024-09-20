namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

public class CareerFranchiseRecordEditModel : EditModel
{
    public CareerFranchiseRecordEditModel() { }

    public CareerFranchiseRecordEditModel(Entity.CareerFranchiseRecord careerFranchiseRecord)
    {
        FranchiseId = careerFranchiseRecord.FranchiseId;
        Person = new PersonModel(careerFranchiseRecord.Person);
        PersonId = careerFranchiseRecord.PersonId;
        Record = careerFranchiseRecord.Record;
        RecordTypeId = careerFranchiseRecord.RecordTypeId;
    }

    public CareerFranchiseRecordEditModel(int franchiseId, int recordTypeId, string record = null, Guid? temporaryId = null)
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

    public Guid? TemporaryId { get; private set; }
}
