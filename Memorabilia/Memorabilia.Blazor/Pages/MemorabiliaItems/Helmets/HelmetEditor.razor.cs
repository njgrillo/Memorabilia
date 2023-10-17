namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Helmets;

public partial class HelmetEditor 
    : MemorabiliaItem<HelmetEditModel>
{
    [Inject]
    public HelmetValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new HelmetModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveHelmet.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
