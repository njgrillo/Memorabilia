namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Baseballs;

public partial class BaseballEditor : MemorabiliaItem<SaveBaseballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBaseball(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            ViewModel.GameStyleTypeId = GameStyleType.None.Id;
            return;
        }

        ViewModel = new SaveBaseballViewModel(viewModel);
    }

    protected async Task OnSave()
    {    
        await CommandRouter.Send(new SaveBaseball.Command(ViewModel));
    }       

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
