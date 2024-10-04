namespace Memorabilia.Application.Features.Tools.Shared.CareerFranchiseRecords;

public class CareerFranchiseRecordsModel
{
    public CareerFranchiseRecordsModel() { }

    public CareerFranchiseRecordsModel(IEnumerable<Entity.CareerFranchiseRecord> careerFranchiseRecords, Constant.Sport sport)
    {
        CareerFranchiseRecords 
            = careerFranchiseRecords.Select(record => new CareerFranchiseRecordModel(record, sport))
                                    .OrderBy(record => record.CareerFranchiseRecordTypeName);
    }

    public IEnumerable<CareerFranchiseRecordModel> CareerFranchiseRecords { get; set; }
        = [];

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName
        => Franchise?.Name;

    public string ResultsTitle
        => $"{FranchiseName} Career Franchise Records";
}
