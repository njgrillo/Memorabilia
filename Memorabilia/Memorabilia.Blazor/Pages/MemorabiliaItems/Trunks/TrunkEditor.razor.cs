namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Trunks;

public partial class TrunkEditor 
    : MemorabiliaItem<TrunkEditModel>
{
    [Inject]
    public TrunkValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new TrunkModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveTrunk.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
