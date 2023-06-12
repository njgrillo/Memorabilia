namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class ViewWritingInstruments 
    : ViewDomainItem<WritingInstrumentsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveWritingInstrument(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new WritingInstrumentsModel(await QueryRouter.Send(new GetWritingInstruments()));
    }
}
