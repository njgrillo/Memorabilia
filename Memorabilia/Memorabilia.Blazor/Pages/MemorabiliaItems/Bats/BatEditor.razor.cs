namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class BatEditor : MemorabiliaItem<SaveBatViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBat(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBatViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBat.Command(ViewModel));
    }
}
