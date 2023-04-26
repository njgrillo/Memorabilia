namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class SportServicePersonEditor 
    : EditPersonItem<SavePersonSportServiceViewModel, PersonSportServiceViewModel>
{
    [Inject]
    public SportServiceValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonSportService.Command(PersonId, ViewModel);

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
         ViewModel = new SavePersonSportServiceViewModel(PersonId, 
                                                        await QueryRouter.Send(new GetPersonSportService(PersonId)));

         PerformValidation = true;
    }    
}
