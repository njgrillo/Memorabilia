namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Guitars;

public partial class GuitarEditor : MemorabiliaItem<SaveGuitarViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetGuitar(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveGuitarViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveGuitar.Command(ViewModel));
    }
}
