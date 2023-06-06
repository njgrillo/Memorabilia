﻿namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors : ViewDomainItem<ColorsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveColor(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetColors());
    }
}
