﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.GolfBalls;

public partial class GolfballEditor 
    : MemorabiliaItem<GolfballEditModel>
{
    [Inject]
    public GolfballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new GolfballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveGolfball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
