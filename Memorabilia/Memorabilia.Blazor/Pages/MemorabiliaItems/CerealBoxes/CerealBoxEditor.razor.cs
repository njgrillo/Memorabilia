namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CerealBoxes;

public partial class CerealBoxEditor : MemorabiliaItem<SaveCerealBoxViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCerealBox(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCerealBoxViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCerealBox.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
