namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Posters;

public partial class PosterEditor : MemorabiliaItem<SavePosterViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPoster.Query(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePosterViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePoster.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
