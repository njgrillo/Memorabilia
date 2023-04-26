namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class TeamPersonEditor 
    : EditPersonItem<SavePersonTeamsViewModel, PersonTeamViewModel>
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
        ViewModel = new SavePersonTeamsViewModel(await QueryRouter.Send(new GetPersonTeams(PersonId)));

        PerformValidation = true;
    }    
}
