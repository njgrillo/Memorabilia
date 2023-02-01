namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Canvases;

public partial class CanvasEditor : MemorabiliaItem<SaveCanvasViewModel>
{
    [Inject]
    public CanvasValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCanvas(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCanvasViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveCanvas.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
