﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Footballs;

public partial class FootballEditor 
    : MemorabiliaItem<FootballEditModel>
{
    [Inject]
    public FootballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new FootballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveFootball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true; await CommandRouter.Send(new SaveFootball.Command(EditModel));
    }
}
