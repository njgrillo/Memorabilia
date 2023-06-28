﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HeadBands;

public partial class HeadBandEditor 
    : MemorabiliaItem<HeadBandEditModel>
{
    [Inject]
    public HeadBandValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new HeadBandModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveHeadBand.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
