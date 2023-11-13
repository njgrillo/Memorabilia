namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PinFlags;

public partial class EditPinFlag 
    : MemorabiliaItem<PinFlagEditModel>
{
    [Inject]
    public PinFlagValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new PinFlagModel(await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        var command = new SavePinFlag.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
