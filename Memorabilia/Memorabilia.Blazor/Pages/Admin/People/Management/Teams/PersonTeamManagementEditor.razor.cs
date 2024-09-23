namespace Memorabilia.Blazor.Pages.Admin.People.Management.Teams;

public partial class PersonTeamManagementEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected PersonTeamManagementEditModel PersonTeamManagementEditModel
        = new();

    protected PersonTeamsManagementEditModel PersonTeamsManagementEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<PersonTeamManagementEditModel> _personTeamManagements
        => PersonTeamsManagementEditModel.PersonTeams
                                         .Where(personTeam => !personTeam.IsDeleted)
                                         .ToList();

    private string _search;

    private void Add()
    {
        if (PersonTeamManagementEditModel.Team.TeamId == 0)
            return;

        PersonTeamsManagementEditModel.PersonTeams.Add(PersonTeamManagementEditModel);

        PersonTeamManagementEditModel = new PersonTeamManagementEditModel();
    }

    private void Edit(PersonTeamManagementEditModel personTeam)
    {
        PersonTeamManagementEditModel.Set(
            personTeam.PersonId,
            personTeam.Team,
            personTeam.BeginYear,
            personTeam.EndYear,
            personTeam.TeamRoleType.Id
            );

        EditMode = EditModeType.Update;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveTeams.Command(PersonTeamsManagementEditModel));

        Snackbar.Add("Teams were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            PersonTeamsManagementEditModel = new PersonTeamsManagementEditModel(SelectedPerson);
            PersonTeamManagementEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        PersonTeamsManagementEditModel = new PersonTeamsManagementEditModel(SelectedPerson);
        PersonTeamManagementEditModel = new();
    }

    private void Update()
    {
        PersonTeamManagementEditModel personTeam
            = PersonTeamsManagementEditModel.PersonTeams
                                            .Single(x => (!x.IsNew && x.Id == PersonTeamManagementEditModel.Team.Id) || x.TemporaryId == PersonTeamManagementEditModel.TemporaryId);

        personTeam.Set(
            PersonTeamManagementEditModel.PersonId,
            PersonTeamManagementEditModel.Team,
            PersonTeamManagementEditModel.BeginYear,
            PersonTeamManagementEditModel.EndYear,
            PersonTeamManagementEditModel.TeamRoleType.Id
            );

        PersonTeamManagementEditModel = new();

        EditMode = EditModeType.Add;
    }
}
