﻿namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class BaseballTypeEditor 
    : EditDomainItem<BaseballType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetBaseballType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBaseballType(EditModel));
    }
}
