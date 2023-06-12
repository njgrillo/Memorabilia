namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tickets;

public partial class TicketEditor : MemorabiliaItem<TicketEditModel>
{
    [Inject]
    public TicketValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new TicketEditModel(new TicketModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveTicket.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
