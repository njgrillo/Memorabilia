namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class WritingInstrumentEditor : EditDomainItem<WritingInstrument>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetWritingInstrument(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveWritingInstrument(ViewModel));
    }
}
