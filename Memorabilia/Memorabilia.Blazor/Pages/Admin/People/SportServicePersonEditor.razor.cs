namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class SportServicePersonEditor 
    : EditPersonItem<PersonSportServiceEditModel, PersonSportServiceModel>
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
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        ViewModel = new PersonSportServiceEditModel(PersonId, new PersonSportServiceModel(person));

        PerformValidation = true;
    }    
}
