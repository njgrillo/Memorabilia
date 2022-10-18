namespace Memorabilia.Blazor.Pages.Admin.RecordTypes;

public partial class RecordTypeEditor : EditDomainItem<RecordType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetRecordType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveRecordType(ViewModel));
    }
}
