namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

public class SportLeadersEditModel : EditModel
{
    public SportLeadersEditModel() { }

    public SportLeadersEditModel(int sportId, int year, Entity.Leader[] leaders)
    {
        SportId = sportId;
        Year = year;

        foreach (Constant.LeaderType leaderType in Constant.LeaderType.GetAll(Constant.Sport.Find(SportId)))
        {
            if (leaders.Any(x => x.LeaderTypeId == leaderType.Id))
            {
                AddLeaders(leaders.Where(x => x.LeaderTypeId == leaderType.Id));
            }
            else
            {
                Leaders.Add(new LeaderEditModel(new Entity.Leader(leaderType.Id), year));
            }
        }
    }

    public List<LeaderEditModel> Leaders { get; set; }
        = [];

    public int SportId { get; set; }

    public int Year { get; set; }

    private void AddLeaders(IEnumerable<Entity.Leader> leaders)
    {
        Leaders.AddRange(leaders.Select(leader => new LeaderEditModel(leader)));
    }
}
