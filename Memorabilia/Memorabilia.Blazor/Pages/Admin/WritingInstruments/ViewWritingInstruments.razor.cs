namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class ViewWritingInstruments 
    : ViewDomainItem<WritingInstrumentsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveWritingInstrument(editModel));
    }

    public async Task OnLoad()
    {
        Model = new WritingInstrumentsModel(await QueryRouter.Send(new GetWritingInstruments()));
    }
}
