namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Figures;

public partial class FigureEditor : MemorabiliaItem<SaveFigureViewModel>
{
    [Inject]
    public FigureValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetFigure(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveFigureViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveFigure.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
