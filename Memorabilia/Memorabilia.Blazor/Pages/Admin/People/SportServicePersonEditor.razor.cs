namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class SportServicePersonEditor 
    : EditPersonItem<PersonSportServiceEditModel, PersonSportServiceModel>
{
    [Inject]
    public SportServiceValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonSportService.Command(PersonId, EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
        {
            PerformValidation = true;
            return;
        }      

        await HandleValidSubmit(command);

        PerformValidation = false;
    }

    protected override async Task OnInitializedAsync()
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = new PersonSportServiceEditModel(PersonId, new PersonSportServiceModel(person));

        PerformValidation = true;
    }    
}
