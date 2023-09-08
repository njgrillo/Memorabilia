namespace Memorabilia.Blazor.Pages.MemorabiliaItems.FirstDayCovers;

public partial class FirstDayCoverEditor : MemorabiliaItem<FirstDayCoverEditModel>
{
    [Inject]
    public FirstDayCoverValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new FirstDayCoverModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveFirstDayCover.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
