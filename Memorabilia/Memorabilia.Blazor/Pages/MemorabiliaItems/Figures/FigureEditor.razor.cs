namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Figures;

public partial class FigureEditor : MemorabiliaItem<SaveFigureViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetFigure(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveFigureViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveFigure.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
