namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

public class FranchiseRecordEditModel : EditModel
{
    public FranchiseRecordEditModel() { }

    public FranchiseRecordEditModel(Entity.Franchise franchise)
    {
        CareerFranchiseRecords
            = franchise.CareerFranchiseRecords
                       .Select(record => new CareerFranchiseRecordEditModel(record))
                       .ToList();

        Franchise = Constant.Franchise.Find(franchise.Id);

        SingleSeasonFranchiseRecords
            = franchise.SingleSeasonFranchiseRecords
                       .Select(record => new SingleSeasonFranchiseRecordEditModel(record))
                       .ToList();

        Sport = Constant.SportLeagueLevel.Find(franchise.SportLeagueLevelId).Sport;
    }

    public List<CareerFranchiseRecordEditModel> CareerFranchiseRecords { get; set; }
        = [];

    public Constant.Franchise Franchise { get; private set; }

    public List<SingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords { get; set; }
        = [];

    public Constant.Sport Sport { get; private set; }
}
