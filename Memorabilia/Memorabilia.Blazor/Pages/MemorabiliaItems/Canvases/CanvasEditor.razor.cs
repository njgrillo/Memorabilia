namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Canvases;

public partial class CanvasEditor : MemorabiliaItem<CanvasEditModel>
{
    [Inject]
    public CanvasValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new CanvasEditModel(new CanvasModel(viewModel));
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
