namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Helmets;

public partial class HelmetEditor : MemorabiliaItem<SaveHelmetViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHelmet(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            ViewModel.GameStyleTypeId = GameStyleType.None.Id;
            return;
        }

        ViewModel = new SaveHelmetViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveHelmet.Command(ViewModel));
    }
}
