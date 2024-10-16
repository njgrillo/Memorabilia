namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

public class FranchiseRetiredNumbersEditModel : EditModel
{
    public FranchiseRetiredNumbersEditModel() { }

    public FranchiseRetiredNumbersEditModel(Entity.Franchise franchise)
    {
        Franchise = Constant.Franchise.Find(franchise.Id);

        RetiredNumbers
            = franchise.RetiredNumbers
                       .Select(record => new FranchiseRetiredNumberEditModel(record))
                       .ToList();

        Sport = Constant.SportLeagueLevel.Find(franchise.SportLeagueLevelId).Sport;
    }

    public Constant.Franchise Franchise { get; private set; }

    public List<FranchiseRetiredNumberEditModel> RetiredNumbers { get; set; }
        = [];

    public Constant.Sport Sport { get; private set; }
}

