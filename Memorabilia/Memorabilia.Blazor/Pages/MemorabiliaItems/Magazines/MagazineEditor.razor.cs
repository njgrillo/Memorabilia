﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Magazines;

public partial class MagazineEditor 
    : MemorabiliaItem<MagazineEditModel>
{
    [Inject]
    public MagazineValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new MagazineEditModel(new MagazineModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveMagazine.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
