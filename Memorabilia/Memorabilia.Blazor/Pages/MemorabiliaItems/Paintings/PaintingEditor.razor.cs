namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Paintings;

public partial class PaintingEditor : MemorabiliaItem<SavePaintingViewModel>
{
    [Inject]
    public PaintingValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPainting(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePaintingViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePainting.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
