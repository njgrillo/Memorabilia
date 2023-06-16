﻿namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor 
    : EditItemTypeItem<ItemTypeBrandEditModel, ItemTypeBrandModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeBrand(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeBrand(Id))).ToEditModel();
    }
}
