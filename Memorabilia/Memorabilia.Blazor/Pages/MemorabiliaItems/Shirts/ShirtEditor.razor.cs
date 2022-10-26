namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shirts;

public partial class ShirtEditor : MemorabiliaItem<SaveShirtViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetShirt(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveShirtViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveShirt.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
