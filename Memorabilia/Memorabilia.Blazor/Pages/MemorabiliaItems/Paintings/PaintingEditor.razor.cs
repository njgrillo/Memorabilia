namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Paintings;

public partial class PaintingEditor : MemorabiliaItem<SavePaintingViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPainting.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePaintingViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePainting.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
