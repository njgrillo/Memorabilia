namespace Memorabilia.Application.Services.Admin.Management.AllStars;

public class AllStarManagementService
{
    private bool _numberOfAllStarsDoesntMatch;

    public bool NumberOfAllStarsDoesntMatch()
        => _numberOfAllStarsDoesntMatch;

    public void Analyze(Entity.AllStarDetail allStarDetail, Entity.AllStar[] allStars)
    {
        if (allStarDetail.NumberOfAllStars == 0)
            return;

        _numberOfAllStarsDoesntMatch = allStars.Length != allStarDetail.NumberOfAllStars;
    }
}
