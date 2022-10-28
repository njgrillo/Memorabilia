namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tennisballs;

public partial class TennisballEditor : MemorabiliaItem<SaveTennisballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTennisball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveTennisballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveTennisball.Command(ViewModel));
    }
}
