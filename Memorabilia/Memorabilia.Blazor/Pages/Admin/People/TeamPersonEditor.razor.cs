namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class TeamPersonEditor 
    : EditPersonItem<PersonTeamsEditModel, PersonTeamModel>
{
    [Inject]
    public TeamValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonTeam.Command(PersonId, EditModel.Teams);

        EditModel.ValidationResult = Validator.Validate(command);        

        if (!EditModel.ValidationResult.IsValid)
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

        EditModel = person.ToTeamEditModel();

        PerformValidation = true;
    }    
}
