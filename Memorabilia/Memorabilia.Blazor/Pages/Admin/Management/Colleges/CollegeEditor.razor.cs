namespace Memorabilia.Blazor.Pages.Admin.Management.Colleges;

public partial class CollegeEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected CollegeEditModel CollegeEditModel
        = new();

    protected CollegesEditModel CollegesEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<CollegeEditModel> _colleges
        => CollegesEditModel.Colleges
                            .Where(College => !College.IsDeleted)
                            .ToList();

    private void Add()
    {
        if (CollegeEditModel.College is null)
            return;

        CollegesEditModel.Colleges.Add(CollegeEditModel);

        CollegeEditModel = new CollegeEditModel();
    }

    private void Edit(CollegeEditModel college)
    {
        CollegeEditModel.Set(college.Id, college.College, college.BeginYear, college.EndYear);

        EditMode = EditModeType.Update;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveColleges.Command(CollegesEditModel));

        Snackbar.Add("Colleges were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            CollegesEditModel = new CollegesEditModel(SelectedPerson);
            CollegeEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        CollegesEditModel = new CollegesEditModel(SelectedPerson);
        CollegeEditModel = new();
    }

    private void Update()
    {
        CollegeEditModel college
            = CollegesEditModel.Colleges.Single(x => (!x.IsNew && x.Id == CollegeEditModel.Id) || x.TemporaryId == CollegeEditModel.TemporaryId);

        college.Set(CollegeEditModel.College, CollegeEditModel.BeginYear, CollegeEditModel.EndYear);

        CollegeEditModel = new();

        EditMode = EditModeType.Add;
    }
}
