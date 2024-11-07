namespace Memorabilia.Blazor.Pages.Admin.People.Management.Services;

public partial class SportServiceEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected SportServiceEditModel EditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    protected bool PersonIsSelected
        => SelectedPerson.Id > 0;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        if (People.Length > 0)
            return;

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: Sport.Baseball.Id));

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveSportService.Command(EditModel));

        Snackbar.Add("Sport Service was saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            EditModel = new SportServiceEditModel(SelectedPerson.SportService);

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        EditModel = new SportServiceEditModel(SelectedPerson.SportService);
    }
}
