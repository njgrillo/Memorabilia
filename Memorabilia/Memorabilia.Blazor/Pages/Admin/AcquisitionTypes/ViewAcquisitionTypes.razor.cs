#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class ViewAcquisitionTypes : ViewDomainItem<AcquisitionTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveAcquisitionType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAcquisitionTypes.Query());
    }
}
