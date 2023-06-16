﻿namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ImageTypeEditor 
    : EditDomainItem<ImageType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetImageType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveImageType(EditModel));
    }
}
