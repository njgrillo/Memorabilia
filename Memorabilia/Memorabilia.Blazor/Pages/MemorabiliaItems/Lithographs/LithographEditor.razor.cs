namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Lithographs;

public partial class LithographEditor 
    : MemorabiliaItem<LithographEditModel>
{
    [Inject]
    public LithographValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new LithographModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveLithograph.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
