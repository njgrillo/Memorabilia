namespace Memorabilia.Application.Features.Admin.Management.AllStars;

public class AllStarManagementModel
{
    private readonly Entity.AllStarDetail _allStarDetail;

    public AllStarManagementModel() { }

    public AllStarManagementModel(Entity.AllStarDetail allStarDetail)
    {
        _allStarDetail = allStarDetail;
    }

    public int AllStarDetailId
        => _allStarDetail.Id;

    public bool IsConfigured
        => _allStarDetail.NumberOfAllStars > 0
        && _allStarDetail.Year > 0;

    public int MonthPlayed 
        => _allStarDetail.MonthPlayed;

    public int NumberOfAllStars
        => _allStarDetail.NumberOfAllStars;

    public bool NumberOfAllStarsDoesntMatch { get; set; }

    public Entity.SportLeagueLevel SportLeagueLevel
        => _allStarDetail.SportLeagueLevel;

    public int Year 
        => _allStarDetail.Year;
}
