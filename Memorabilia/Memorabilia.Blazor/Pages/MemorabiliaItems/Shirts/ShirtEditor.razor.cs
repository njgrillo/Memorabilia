﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shirts;

public partial class ShirtEditor 
    : MemorabiliaItem<ShirtEditModel>
{
    [Inject]
    public ShirtValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new ShirtModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveShirt.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
