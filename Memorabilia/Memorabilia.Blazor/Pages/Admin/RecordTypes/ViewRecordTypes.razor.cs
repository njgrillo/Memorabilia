namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class ViewRecordTypes 
    : ViewDomainItem<RecordTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveRecordType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new RecordTypesModel(await QueryRouter.Send(new GetRecordTypes()));
    }
}
