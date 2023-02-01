namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Baseballs;

public partial class BaseballEditor : MemorabiliaItem<SaveBaseballViewModel>
{
    [Inject]
    public BaseballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBaseball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBaseballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveBaseball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }    
}
