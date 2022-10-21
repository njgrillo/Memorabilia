namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Hats;

public partial class HatEditor : MemorabiliaItem<SaveHatViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHat(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHatViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveHat.Command(ViewModel));
    }
}
