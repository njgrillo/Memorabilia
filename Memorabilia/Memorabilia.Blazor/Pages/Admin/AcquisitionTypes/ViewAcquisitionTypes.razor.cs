﻿namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class ViewAcquisitionTypes : ViewDomainItem<AcquisitionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveAcquisitionType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new AcquisitionTypesModel(await QueryRouter.Send(new GetAcquisitionTypes()));
    }
}
