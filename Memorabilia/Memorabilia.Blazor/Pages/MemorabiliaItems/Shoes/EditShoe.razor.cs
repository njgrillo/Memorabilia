namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shoes;

public partial class EditShoe 
    : MemorabiliaItem<ShoeEditModel>
{
    [Inject]
    public ShoeValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new ShoeModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveShoe.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
