namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Jerseys;

public partial class JerseyEditor : MemorabiliaItem<JerseyEditModel>
{
    [Inject]
    public JerseyValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new JerseyEditModel(new JerseyModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveJersey.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
