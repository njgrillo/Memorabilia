namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

public class SportAllStarYearViewModel
{
    private readonly Entity.AllStar[] _allStars;

    public SportAllStarYearViewModel() { }

    public SportAllStarYearViewModel(int sportId, int year, Entity.AllStar[] allStars)
    {
        _allStars = allStars;
        Sport = Constant.Sport.Find(sportId);
        Year = year;
    }

    public int Count
        => _allStars.Length;

    public Constant.Sport Sport { get; set; }

    public string SportName
        => Sport?.Name;

    public int Year { get; set; }
}
