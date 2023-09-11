namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tickets;

public partial class TicketEditor
    : MemorabiliaItem<TicketEditModel>
{
    [Inject]
    public TicketValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new TicketModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveTicket.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
