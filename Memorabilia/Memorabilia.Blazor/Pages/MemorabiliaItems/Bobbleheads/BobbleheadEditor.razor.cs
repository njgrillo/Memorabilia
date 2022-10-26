namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bobbleheads;

public partial class BobbleheadEditor : MemorabiliaItem<SaveBobbleheadViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBobblehead(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBobbleheadViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBobblehead.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
