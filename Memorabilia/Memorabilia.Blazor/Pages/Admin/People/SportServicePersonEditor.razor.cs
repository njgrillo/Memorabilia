namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class SportServicePersonEditor 
    : EditPersonItem<PersonSportServiceEditModel, PersonSportServiceModel>
{
    [Inject]
    public SportServiceValidator Validator { get; set; } 

    protected override async Task OnInitializedAsync()
    {
        Entity.Person person = await Mediator.Send(new GetPerson(PersonId));

        EditModel = new PersonSportServiceEditModel(PersonId, new PersonSportServiceModel(person));

        IsLoaded = true;
    }

    protected async Task Save()
    {
        var command = new SavePersonSportService.Command(PersonId, EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Save(command);
    }
}
