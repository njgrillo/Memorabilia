namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs;

public partial class BasketballEditor : MemorabiliaItem<SaveBasketballViewModel>
{
    protected async Task OnLoad()
    {      
        var viewModel = await QueryRouter.Send(new GetBasketball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBasketballViewModel(viewModel);
    }    

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBasketball.Command(ViewModel));
    }
}
