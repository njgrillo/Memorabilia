namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs;

public partial class BasketballEditor : MemorabiliaItem<BasketballEditModel>
{
    [Inject]
    public BasketballValidator Validator { get; set; }

    protected async Task OnLoad()
    {      
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new BasketballEditModel(new BasketballModel(viewModel));
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
