namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class TeamPersonEditor 
    : EditPersonItem<PersonTeamsEditModel, PersonTeamModel>
{
    [Inject]
    public TeamValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonTeam.Command(PersonId, ViewModel.Teams);

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

        ViewModel = new PersonTeamsEditModel(new PersonTeamsModel(person));

        PerformValidation = true;
    }    
}
