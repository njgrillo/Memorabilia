﻿#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges : ViewDomainItem<CollegesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveCollege.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetColleges.Query());
    }
}
