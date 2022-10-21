namespace Memorabilia.Blazor.Pages.MemorabiliaItems.TennisRackets;

public partial class TennisRacketEditor : MemorabiliaItem<SaveTennisRacketViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTennisRacket(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveTennisRacketViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveTennisRacket.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
