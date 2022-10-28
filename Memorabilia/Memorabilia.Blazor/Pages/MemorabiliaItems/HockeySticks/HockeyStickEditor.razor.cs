﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HockeySticks;

public partial class HockeyStickEditor : MemorabiliaItem<SaveHockeyStickViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHockeyStick(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHockeyStickViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveHockeyStick.Command(ViewModel));
    }
}
