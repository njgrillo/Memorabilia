namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

public class FranchiseRetiredNumbersViewModel : Model
{
    public FranchiseRetiredNumbersViewModel() { }

    public FranchiseRetiredNumbersViewModel(
        IEnumerable<Entity.Franchise> franchises,
        PageInfoResult pageInfo
        )
    {
        Franchises
            = franchises.Select(franchise => new FranchiseRetiredNumberViewModel(franchise))
                        .ToList();

        PageInfo = pageInfo;
    }

    public List<FranchiseRetiredNumberViewModel> Franchises { get; set; }
        = [];
}
