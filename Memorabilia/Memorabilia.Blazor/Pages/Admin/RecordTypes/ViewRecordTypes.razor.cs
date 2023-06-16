namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class ViewRecordTypes 
    : ViewDomainItem<RecordTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveRecordType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new RecordTypesModel(await QueryRouter.Send(new GetRecordTypes()));
    }
}
