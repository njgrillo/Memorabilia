namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bobbleheads;

public partial class BobbleheadEditor 
    : MemorabiliaItem<BobbleheadEditModel>
{
    [Inject]
    public BobbleheadValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BobbleheadModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveBobblehead.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
