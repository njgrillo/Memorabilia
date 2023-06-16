﻿namespace Memorabilia.Blazor.Pages.Admin.PurchaseTypes;

public partial class PurchaseTypeEditor 
    : EditDomainItem<PurchaseType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetPurchaseType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePurchaseType(EditModel));
    }
}
