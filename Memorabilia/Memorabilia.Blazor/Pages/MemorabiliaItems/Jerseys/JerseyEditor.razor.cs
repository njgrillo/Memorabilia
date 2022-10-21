namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Jerseys;

public partial class JerseyEditor : MemorabiliaItem<SaveJerseyViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetJersey(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            SetDefaults();
            return;
        }

        ViewModel = new SaveJerseyViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveJersey.Command(ViewModel));
    }

    private void SetDefaults()
    {
        ViewModel.GameStyleTypeId = GameStyleType.None.Id;
    }
}
