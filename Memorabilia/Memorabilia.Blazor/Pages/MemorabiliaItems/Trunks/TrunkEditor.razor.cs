namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Trunks;

public partial class TrunkEditor : MemorabiliaItem<SaveTrunkViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTrunk.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveTrunkViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveTrunk.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
