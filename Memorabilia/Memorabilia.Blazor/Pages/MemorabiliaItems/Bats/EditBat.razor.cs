namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class EditBat 
    : MemorabiliaItem<BatEditModel>
{
    [Inject]
    public BatValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BatModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveBat.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
