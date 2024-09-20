namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

public class FranchiseRecordsViewModel : Model
{
    public FranchiseRecordsViewModel() { }

    public FranchiseRecordsViewModel(
        IEnumerable<Entity.Franchise> franchises,
        PageInfoResult pageInfo
        )
    {
        Franchises
            = franchises.Select(franchise => new FranchiseRecordViewModel(franchise))
                        .ToList();

        PageInfo = pageInfo;
    }

    public List<FranchiseRecordViewModel> Franchises { get; set; }
        = [];
}
