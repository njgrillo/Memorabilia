namespace Memorabilia.Blazor.Pages.MemorabiliaItems.WristBands;

public partial class EditWristBand 
    : MemorabiliaItem<WristBandEditModel>
{
    [Inject]
    public WristBandValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new WristBandModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveWristBand.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
