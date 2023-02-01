namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Books;

public partial class BookEditor : MemorabiliaItem<SaveBookViewModel>
{
    [Inject]
    public BookValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        ViewModel = new SaveBookViewModel(await QueryRouter.Send(new GetBook(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        var command = new SaveBook.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
