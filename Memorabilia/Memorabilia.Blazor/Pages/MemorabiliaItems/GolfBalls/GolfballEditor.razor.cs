﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.GolfBalls;

public partial class GolfballEditor : MemorabiliaItem<SaveGolfballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetGolfball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveGolfballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveGolfball.Command(ViewModel));
    }
}
