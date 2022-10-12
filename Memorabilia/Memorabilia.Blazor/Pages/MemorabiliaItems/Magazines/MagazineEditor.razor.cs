namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Magazines;

public partial class MagazineEditor : MemorabiliaItem<SaveMagazineViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMagazine.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveMagazineViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveMagazine.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
