namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tickets;

public partial class TicketEditor : MemorabiliaItem<SaveTicketViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTicket(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SaveTicketViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveTicket.Command(ViewModel));
    }
}
