namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Lithographs;

public partial class LithographEditor : MemorabiliaItem<SaveLithographViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetLithograph(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveLithographViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveLithograph.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
