namespace Memorabilia.Blazor.Pages.MemorabiliaItems.JerseyNumbers;

public partial class JerseyNumberEditor 
    : MemorabiliaItem<JerseyNumberEditModel>
{
    [Inject]
    public JerseyNumberValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new JerseyNumberModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        var command = new SaveJerseyNumber.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
