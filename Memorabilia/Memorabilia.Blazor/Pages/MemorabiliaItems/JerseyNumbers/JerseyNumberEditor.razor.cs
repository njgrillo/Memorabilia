namespace Memorabilia.Blazor.Pages.MemorabiliaItems.JerseyNumbers;

public partial class JerseyNumberEditor : MemorabiliaItem<JerseyNumberEditModel>
{
    [Inject]
    public JerseyNumberValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        ViewModel = new JerseyNumberEditModel(new JerseyNumberModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        var command = new SaveJerseyNumber.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
