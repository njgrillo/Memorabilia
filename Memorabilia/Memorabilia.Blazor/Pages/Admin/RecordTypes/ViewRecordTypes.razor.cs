namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class ViewRecordTypes 
    : ViewDomainItem<RecordTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveRecordType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new RecordTypesModel(await QueryRouter.Send(new GetRecordTypes()));
    }
}
