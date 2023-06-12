namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Soccerballs;

public partial class SoccerballEditor : MemorabiliaItem<SoccerballEditModel>
{
    [Inject]
    public SoccerballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SoccerballEditModel(new SoccerballModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveSoccerball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
