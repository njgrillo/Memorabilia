namespace Memorabilia.Application.Features.Admin.Management.Accomplishments.Records;

public class FranchiseRecordViewModel
{
    private readonly Entity.Franchise _franchise;

    public FranchiseRecordViewModel() { }

    public FranchiseRecordViewModel(Entity.Franchise franchise)
    {
        _franchise = franchise;
    }

    public int CareerRecordCount
        => _franchise.CareerFranchiseRecords.Count;

    public int FranchiseId
        => _franchise.Id;

    public string FranchiseName
        => _franchise.Name;

    public int SingleSeasonRecordCount
        => _franchise.SingleSeasonFranchiseRecords.Count;

    public bool Search(string search)
        => search.IsNullOrEmpty() ||
           FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
