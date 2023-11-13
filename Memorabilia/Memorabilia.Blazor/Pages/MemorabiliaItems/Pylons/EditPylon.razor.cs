namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pylons;

public partial class EditPylon 
    : MemorabiliaItem<PylonEditModel>
{
    [Inject]
    public PylonValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new PylonModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePylon.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
