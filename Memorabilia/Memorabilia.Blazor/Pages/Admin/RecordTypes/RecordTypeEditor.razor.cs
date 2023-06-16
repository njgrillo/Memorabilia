namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class RecordTypeEditor 
    : EditDomainItem<RecordType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetRecordType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveRecordType(EditModel));
    }
}
