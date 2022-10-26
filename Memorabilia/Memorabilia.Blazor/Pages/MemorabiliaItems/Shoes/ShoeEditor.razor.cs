namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shoes;

public partial class ShoeEditor : MemorabiliaItem<SaveShoeViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetShoe(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveShoeViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveShoe.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
