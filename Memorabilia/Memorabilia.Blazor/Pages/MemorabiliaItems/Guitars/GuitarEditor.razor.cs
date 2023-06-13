﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Guitars;

public partial class GuitarEditor 
    : MemorabiliaItem<GuitarEditModel>
{
    [Inject]
    public GuitarValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new GuitarModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveGuitar.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
