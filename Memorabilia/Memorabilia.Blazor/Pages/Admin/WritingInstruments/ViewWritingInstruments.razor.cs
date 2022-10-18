namespace Memorabilia.Blazor.Pages.Admin.WritingInstruments;

public partial class ViewWritingInstruments : ViewDomainItem<WritingInstrumentsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveWritingInstrument(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetWritingInstruments());
    }
}
