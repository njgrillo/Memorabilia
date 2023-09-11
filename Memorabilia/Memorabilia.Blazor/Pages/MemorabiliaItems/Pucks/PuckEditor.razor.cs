namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pucks;

public partial class PuckEditor 
    : MemorabiliaItem<PuckEditModel>
{
    [Inject]
    public PuckValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new PuckModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePuck.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
