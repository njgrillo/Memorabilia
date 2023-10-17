namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class ViewWritingInstruments 
    : ViewDomainItem<WritingInstrumentsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveWritingInstrument(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new WritingInstrumentsModel(await Mediator.Send(new GetWritingInstruments()));
    }
}
