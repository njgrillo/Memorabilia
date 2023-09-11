namespace Memorabilia.Blazor.Pages.MemorabiliaItems.TennisRackets;

public partial class TennisRacketEditor 
    : MemorabiliaItem<TennisRacketEditModel>
{
    [Inject]
    public TennisRacketValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new TennisRacketModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveTennisRacket.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
