namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pants;

public partial class EditPant 
    : MemorabiliaItem<PantEditModel>
{
    [Inject]
    public PantValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new PantModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePant.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
