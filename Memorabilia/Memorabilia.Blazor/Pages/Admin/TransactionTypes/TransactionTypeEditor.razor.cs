﻿namespace Memorabilia.Blazor.Pages.Admin.TransactionTypes;

public partial class TransactionTypeEditor
    : EditDomainItem<TransactionType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetTransactionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveTransactionType(EditModel));
    }
}
