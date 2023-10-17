namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shirts;

public partial class ShirtEditor 
    : MemorabiliaItem<ShirtEditModel>
{
    [Inject]
    public ShirtValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new ShirtModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveShirt.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
