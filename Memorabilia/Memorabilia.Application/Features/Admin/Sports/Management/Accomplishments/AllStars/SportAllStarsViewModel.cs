namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

public class SportAllStarsViewModel
{
    private readonly Entity.AllStar[] _allStars;
    private readonly int _sportId;

    public SportAllStarsViewModel() { }

    public SportAllStarsViewModel(int sportId, Entity.AllStar[] allStars)
    {
        _allStars = allStars;
        _sportId = sportId;

        var groupedItems = allStars
            .GroupBy(item => new { item.SportId, item.Year })
            .Select(g => new
            {
                g.Key.SportId,
                g.Key.Year,
                Items = g.ToList()
            })
            .OrderByDescending(x => x.Year);

        Items = groupedItems.Select(x => new SportAllStarYearViewModel(x.SportId, x.Year, x.Items.ToArray())).ToList();
    }

    public Entity.AllStar[] AllStars
        => _allStars;

    public List<SportAllStarYearViewModel> Items { get; set; }
        = [];

    public Constant.Sport Sport
        => Constant.Sport.Find(SportId);

    public int SportId
        => _sportId;    
}
