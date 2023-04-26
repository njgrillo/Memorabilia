namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class AccoladePersonEditor 
    : EditPersonItem<SavePersonAccoladeViewModel, PersonAccoladeViewModel>
{
    [Inject]
    public AccoladeValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonAccolades.Command(PersonId, ViewModel);        

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
        {
            PerformValidation = true;
            return;
        }

        await HandleValidSubmit(command);

        PerformValidation = false;
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonAccoladeViewModel(PersonId, await Get(new GetPersonAccomplishments(PersonId)));

        PerformValidation = true;
    }    
}
