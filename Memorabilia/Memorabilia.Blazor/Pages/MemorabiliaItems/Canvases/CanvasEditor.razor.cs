namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Canvases;

public partial class CanvasEditor : MemorabiliaItem<SaveCanvasViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCanvas(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCanvasViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCanvas.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
