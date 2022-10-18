﻿namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class SizeEditor : EditDomainItem<Domain.Constants.Size>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetSize(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveSize(ViewModel));
    }
}
