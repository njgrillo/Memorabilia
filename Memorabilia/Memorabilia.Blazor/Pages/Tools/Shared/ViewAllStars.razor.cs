namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAllStars : ViewSportTools<AllStarViewModel>
{
    protected bool FilterFuncSecondaryGrid(AllStarViewModel viewModel) => FilterFuncSecondary(viewModel, SecondarySearch);

    protected string SecondarySearch;

    public int BeginYear
        => Sport.Name switch
        {
            "Baseball" => 1933,
            "Basketball" => 1951,
            "Football" => 1951,
            _ => 1950
        };

    private AllStarsViewModel _viewModel = new();

    private async Task OnInputChange(int year)
    {
        _viewModel = await QueryRouter.Send(new GetAllStars(year, Sport));

        if (_viewModel.IsDoubleHeaderAllStarGame)
        {
            int[] personIds = _viewModel.AllStars
                                        .GroupBy(allStar => allStar.PersonId)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key)
                                        .ToArray();

            _viewModel.AllStars = _viewModel.AllStars
                                            .DistinctBy(allStar => allStar.PersonId)
                                            .ToList();

            foreach (AllStarViewModel allStar in _viewModel.AllStars.Where(allStar => personIds.Contains(allStar.PersonId)))
            {
                allStar.NumberOfGames = 2;
            }
        }
    }    

    protected bool FilterFuncSecondary(AllStarViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.Name,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }
}
