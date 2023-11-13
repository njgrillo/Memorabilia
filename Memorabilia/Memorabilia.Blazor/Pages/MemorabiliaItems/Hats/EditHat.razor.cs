namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Hats;

public partial class EditHat 
    : MemorabiliaItem<HatEditModel>
{
    [Inject]
    public HatValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new HatModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveHat.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
