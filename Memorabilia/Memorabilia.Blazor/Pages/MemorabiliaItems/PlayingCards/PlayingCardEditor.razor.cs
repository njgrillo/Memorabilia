namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PlayingCards;

public partial class PlayingCardEditor 
    : MemorabiliaItem<PlayingCardEditModel>
{
    [Inject]
    public PlayingCardValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new PlayingCardModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePlayingCard.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
