namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs;

public partial class BasketballEditor : MemorabiliaItem<SaveBasketballViewModel>
{
    [Inject]
    public BasketballValidator Validator { get; set; }

    protected async Task OnLoad()
    {      
        var viewModel = await QueryRouter.Send(new GetBasketball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBasketballViewModel(viewModel);
    }    

    protected async Task OnSave()
    {
        var command = new SaveBasketball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
