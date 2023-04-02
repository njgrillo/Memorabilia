﻿namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAllStars : ViewSportTools<AllStarViewModel>
{
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
}
