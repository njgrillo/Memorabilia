namespace Memorabilia.Blazor.Pages.Admin.People.Management.Accomplishments;

public partial class AccomplishmentEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected AccomplishmentEditModel AccomplishmentEditModel
        = new();

    protected AccomplishmentsEditModel AccomplishmentsEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected bool PersonIsSelected
        => SelectedPerson.Id > 0;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<AccomplishmentEditModel> _Accomplishments
        => AccomplishmentsEditModel.Accomplishments
                                   .Where(accomplishment => !accomplishment.IsDeleted)
                                   .OrderBy(accomplishment => accomplishment.AccomplishmentTypeName)
                                   .ToList();

    private string _search;
    private string _years;

    private void Add()
    {
        if (AccomplishmentEditModel.AccomplishmentType is null)
            return;

        AccomplishmentsEditModel
            .Accomplishments
            .AddRange(_years.ToIntArray().Select(year => new AccomplishmentEditModel(AccomplishmentEditModel.AccomplishmentType, AccomplishmentEditModel.Date, SelectedPerson.Id, year)));

        AccomplishmentEditModel = new();

        _years = string.Empty;
    }

    private void Edit(AccomplishmentEditModel accomplishment)
    {
        AccomplishmentEditModel.Set(accomplishment.AccomplishmentType.Id, accomplishment.Date, accomplishment.Year);

        EditMode = EditModeType.Update;
    }

    private bool Filter(AccomplishmentEditModel accomplishment)
        => accomplishment.Search(_search);

    private async void OnSave()
    {
        await Mediator.Send(new SaveAccomplishments.Command(AccomplishmentsEditModel));

        Snackbar.Add("Accomplishments were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            AccomplishmentsEditModel = new AccomplishmentsEditModel(SelectedPerson);
            AccomplishmentEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        AccomplishmentsEditModel = new AccomplishmentsEditModel(SelectedPerson);
        AccomplishmentEditModel = new();
    }

    private void Update()
    {
        AccomplishmentEditModel accomplishment
            = AccomplishmentsEditModel.Accomplishments.Single(x => (!x.IsNew && x.Id == AccomplishmentEditModel.Id) || x.TemporaryId == AccomplishmentEditModel.TemporaryId);

        accomplishment.Set(AccomplishmentEditModel.AccomplishmentType.Id, AccomplishmentEditModel.Date, AccomplishmentEditModel.Year);

        AccomplishmentEditModel = new();

        EditMode = EditModeType.Add;
    }
}
