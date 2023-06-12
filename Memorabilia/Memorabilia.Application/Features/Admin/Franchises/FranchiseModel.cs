namespace Memorabilia.Application.Features.Admin.Franchises;

public class FranchiseModel
{
    private readonly Entity.Franchise _franchise;

    public FranchiseModel() { }

    public FranchiseModel(Entity.Franchise franchise)
    {
        _franchise = franchise;
    }

    public int FoundYear 
        => _franchise.FoundYear;

    public string FullName 
        => _franchise.FullName;

    public int Id 
        => _franchise.Id;

    public string ImageFileName 
        => _franchise.ImageFileName;

    public DateTime? LastModifiedDate 
        => _franchise.LastModifiedDate;

    public string Location 
        => _franchise.Location;

    public string Name 
        => _franchise.Name;

    public int SportLeagueLevelId 
        => _franchise.SportLeagueLevelId;

    public string SportLeagueLevelName 
        => _franchise.SportLeagueLevelName;
}
