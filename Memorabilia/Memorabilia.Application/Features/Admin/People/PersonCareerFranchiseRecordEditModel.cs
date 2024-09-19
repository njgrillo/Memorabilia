namespace Memorabilia.Application.Features.Admin.People;

public class PersonCareerFranchiseRecordEditModel : EditModel
{
    public PersonCareerFranchiseRecordEditModel() { }

    public PersonCareerFranchiseRecordEditModel(Entity.CareerFranchiseRecord careerFranchiseRecord)
    {
        Franchise = Constant.Franchise.Find(careerFranchiseRecord.FranchiseId);        
        Id = careerFranchiseRecord.Id;
        PersonId = careerFranchiseRecord.PersonId;
        Record = careerFranchiseRecord.Record;
        RecordType = Constant.RecordType.Find(careerFranchiseRecord.RecordTypeId);
    }    

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName
        => Franchise?.Name;

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName
        => RecordType?.Name;

    public bool Search(string search)
        => search.IsNullOrEmpty() ||
           FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           Record.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           RecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);

    public void SetFranchise(Constant.Franchise[] franchises)
    {
        if (franchises.Length != 1)
            return;

        Franchise = franchises.First();
    }

    public void Update(string record, Constant.Franchise franchise, Constant.RecordType recordType = null)
    {
        Record = record;
        Franchise = franchise;

        if (RecordType is null)
            return;

        RecordType = recordType;
    }
}
