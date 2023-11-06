namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class EditHallOfFamePerson
    : EditPersonItem<PersonHallOfFamesEditModel, PersonHallOfFameModel>
{
    [Inject]
    public HallOfFameValidator Validator { get; set; }    

    protected override async Task OnInitializedAsync()
    {
        var model = new PersonHallOfFameModel(await Mediator.Send(new GetPerson(PersonId)));

        EditModel = new PersonHallOfFamesEditModel(PersonId, model);

        IsLoaded = true;
    }

    protected async Task Save()
    {
        var command = new SavePersonHallOfFame.Command(PersonId, EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Save(new SavePersonHallOfFame.Command(PersonId, EditModel));
    }
}
