namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pucks;

public partial class PuckEditor : MemorabiliaItem<SavePuckViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPuck(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePuckViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePuck.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
