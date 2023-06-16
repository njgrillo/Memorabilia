﻿namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class HelmetFinishEditor 
    : EditDomainItem<HelmetFinish>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetHelmetFinish(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetFinish(EditModel));
    }
}
