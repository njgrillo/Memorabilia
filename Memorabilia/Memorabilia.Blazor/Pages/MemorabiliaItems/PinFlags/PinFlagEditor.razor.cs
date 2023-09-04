﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PinFlags;

public partial class PinFlagEditor 
    : MemorabiliaItem<PinFlagEditModel>
{
    [Inject]
    public PinFlagValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new PinFlagModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        var command = new SavePinFlag.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
