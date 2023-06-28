namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class TeamPersonEditor 
    : EditPersonItem<PersonTeamsEditModel, PersonTeamModel>
{
    [Inject]
    public TeamValidator Validator { get; set; }    

    protected override async Task OnInitializedAsync()
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = person.ToTeamEditModel();

        IsLoaded = true;
    }

    protected async Task Save()
    {
        var command = new SavePersonTeam.Command(PersonId, EditModel.Teams);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Save(command);
    }
}
