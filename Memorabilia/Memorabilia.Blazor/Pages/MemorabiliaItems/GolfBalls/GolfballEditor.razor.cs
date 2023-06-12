namespace Memorabilia.Blazor.Pages.MemorabiliaItems.GolfBalls;

public partial class GolfballEditor : MemorabiliaItem<GolfballEditModel>
{
    [Inject]
    public GolfballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new GolfballEditModel(new GolfballModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveGolfball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
