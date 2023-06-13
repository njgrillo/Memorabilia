﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Drums;

public partial class DrumEditor 
    : MemorabiliaItem<DrumEditModel>
{
    [Inject]
    public DrumValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new DrumModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveDrum.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
