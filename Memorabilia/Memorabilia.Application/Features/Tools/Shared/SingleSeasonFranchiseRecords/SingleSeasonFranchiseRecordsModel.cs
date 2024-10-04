namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonFranchiseRecords;

public class SingleSeasonFranchiseRecordsModel
{
    public SingleSeasonFranchiseRecordsModel() { }

    public SingleSeasonFranchiseRecordsModel(
        IEnumerable<Entity.SingleSeasonFranchiseRecord> singleSeasonFranchiseRecords, 
        Constant.Sport sport
        )
    {
        SingleSeasonFranchiseRecords
            = singleSeasonFranchiseRecords.Select(record => new SingleSeasonFranchiseRecordModel(record, sport))
                                          .OrderBy(record => record.SingleSeasonRecordTypeName);
    }    

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName
        => Franchise?.Name;

    public string ResultsTitle
        => $"{FranchiseName} Single Season Franchise Records";

    public IEnumerable<SingleSeasonFranchiseRecordModel> SingleSeasonFranchiseRecords { get; set; }
        = [];
}
