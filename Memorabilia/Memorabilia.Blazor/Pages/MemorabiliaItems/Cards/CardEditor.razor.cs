namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Cards;

public partial class CardEditor 
    : MemorabiliaItem<CardEditModel>
{
    [Inject]
    public CardValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new CardEditModel(new CardModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveCard.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
