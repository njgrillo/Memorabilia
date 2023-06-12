namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAllStars 
    : ViewSportTools<AllStarModel>
{
    protected int BeginYear
        => Sport.Name switch
        {
            "Baseball" => 1933,
            "Basketball" => 1951,
            "Football" => 1938,
            _ => 1950
        };

    protected AllStarsModel Model 
        = new();

    private string _secondarySearch;

    protected bool FilterFuncSecondaryGrid(AllStarModel allStar)
        => FilterFuncSecondary(allStar, _secondarySearch);

    protected static bool FilterFuncSecondary(AllStarModel allStar, string search)
        => search.IsNullOrEmpty() ||
           allStar.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(allStar.Name,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;

    private async Task OnInputChange(int year)
    {
        Model = new AllStarsModel(await QueryRouter.Send(new GetAllStars(year, Sport)), Sport, year);

        if (Model.IsDoubleHeaderAllStarGame)
        {
            int[] personIds = Model.AllStars
                                   .GroupBy(allStar => allStar.PersonId)
                                   .Where(g => g.Count() > 1)
                                   .Select(x => x.Key)
                                   .ToArray();

            Model.AllStars = Model.AllStars
                                  .DistinctBy(allStar => allStar.PersonId)
                                  .ToList();

            foreach (AllStarModel allStar in Model.AllStars.Where(allStar => personIds.Contains(allStar.PersonId)))
            {
                allStar.NumberOfGames = 2;
            }
        }
    }        
}
