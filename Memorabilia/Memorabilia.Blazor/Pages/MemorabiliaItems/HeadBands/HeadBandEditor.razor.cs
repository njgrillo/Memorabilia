﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HeadBands;

public partial class HeadBandEditor : MemorabiliaItem<HeadBandEditModel>
{
    [Inject]
    public HeadBandValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new HeadBandEditModel(new HeadBandModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveHeadBand.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
