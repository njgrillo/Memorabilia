namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Soccerballs;

public partial class SoccerballEditor : MemorabiliaItem<SaveSoccerballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetSoccerball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveSoccerballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveSoccerball.Command(ViewModel));
    }
}
