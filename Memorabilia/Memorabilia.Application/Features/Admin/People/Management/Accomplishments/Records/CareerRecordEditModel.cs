namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

public class CareerRecordEditModel : EditModel
{
    public CareerRecordEditModel() { }

    public CareerRecordEditModel(Entity.CareerRecord careerRecord)
    {
        Id = careerRecord.Id;
        Person = new PersonModel(careerRecord.Person);
        Record = careerRecord.Record;
        RecordTypeId = careerRecord.RecordTypeId;
    }

    public CareerRecordEditModel(int personId, int recordTypeId, string record = null)
    {
        PersonId = personId;
        RecordTypeId = recordTypeId;
        Record = record;
    }

    public int FranchiseId { get; set; }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public string Record { get; set; }

    public int RecordTypeId { get; set; }

    public string RecordTypeName
        => Constant.RecordType.Find(RecordTypeId)?.Name;
}
