namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class WritingInstrumentEditor 
    : EditDomainItem<WritingInstrument>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetWritingInstrument(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveWritingInstrument(EditModel));
    }
}
