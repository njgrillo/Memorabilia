namespace Memorabilia.Blazor.Pages.MemorabiliaItems.FirstDayCovers;

public partial class FirstDayCoverEditor : MemorabiliaItem<SaveFirstDayCoverViewModel>
{
    [Inject]
    public FirstDayCoverValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetFirstDayCover(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SaveFirstDayCoverViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveFirstDayCover.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
