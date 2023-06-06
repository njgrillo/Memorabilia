namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class ViewRecordTypes : ViewDomainItem<RecordTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveRecordType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetRecordTypes());
    }
}
