namespace Memorabilia.Blazor.Pages.MemorabiliaItems.WristBands;

public partial class WristBandEditor 
    : MemorabiliaItem<WristBandEditModel>
{
    [Inject]
    public WristBandValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

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

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
