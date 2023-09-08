namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HockeySticks;

public partial class HockeyStickEditor 
    : MemorabiliaItem<HockeyStickEditModel>
{
    [Inject]
    public HockeyStickValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new HockeyStickModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveHockeyStick.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
