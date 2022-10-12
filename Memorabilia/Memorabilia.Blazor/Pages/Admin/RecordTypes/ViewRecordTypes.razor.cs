namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class ViewRecordTypes : ViewDomainItem<RecordTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveRecordType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetRecordTypes.Query());
    }
}
