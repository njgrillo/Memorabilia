namespace Memorabilia.Application.Features.Admin.People;

public class PersonSingleSeasonFranchiseRecordEditModel : EditModel
{
    public PersonSingleSeasonFranchiseRecordEditModel() { }

    public PersonSingleSeasonFranchiseRecordEditModel(Entity.SingleSeasonFranchiseRecord singleSeasonFranchiseRecord)
    {
        Franchise = Constant.Franchise.Find(singleSeasonFranchiseRecord.FranchiseId);
        Id = singleSeasonFranchiseRecord.Id;
        PersonId = singleSeasonFranchiseRecord.PersonId;
        Record = singleSeasonFranchiseRecord.Record;
        RecordType = Constant.RecordType.Find(singleSeasonFranchiseRecord.RecordTypeId);
        Year = singleSeasonFranchiseRecord.Year;
    }

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName
        => Franchise?.Name;

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName
        => RecordType?.Name;

    public int? Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           Record.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           RecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }

    public void SetFranchise(Constant.Franchise[] franchises)
    {
        if (franchises.Length != 1)
            return;

        Franchise = franchises.First();
    }

    public void Update(Constant.RecordType recordType, Constant.Franchise franchise, int? year, string record)
    {
        RecordType = recordType;
        Franchise = franchise;
        Year = year;
        Record = record;
    }
}
