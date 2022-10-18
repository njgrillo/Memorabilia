﻿namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes : ViewDomainItem<GameStyleTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveGameStyleType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetGameStyleTypes());
    }
}
