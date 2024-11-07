namespace Memorabilia.Blazor.Pages.Admin.People.Management.Colleges;

public partial class CollegeEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected ManageCollegeEditModel CollegeEditModel
        = new();

    protected ManageCollegesEditModel CollegesEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected bool PersonIsSelected
        => SelectedPerson.Id > 0;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<ManageCollegeEditModel> _colleges
        => CollegesEditModel.Colleges
                            .Where(college => !college.IsDeleted)
                            .OrderBy(college => college.Name)
                            .ToList();

    private void Add()
    {
        if (CollegeEditModel.College is null)
            return;

        CollegesEditModel.Colleges.Add(CollegeEditModel);

        CollegeEditModel = new ManageCollegeEditModel();
    }

    private void Edit(ManageCollegeEditModel college)
    {
        CollegeEditModel.Set(college.Id, college.College, college.BeginYear, college.EndYear);

        EditMode = EditModeType.Update;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveManageColleges.Command(CollegesEditModel));

        Snackbar.Add("Colleges were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            CollegesEditModel = new ManageCollegesEditModel(SelectedPerson);
            CollegeEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        CollegesEditModel = new ManageCollegesEditModel(SelectedPerson);
        CollegeEditModel = new();
    }

    private void Update()
    {
        ManageCollegeEditModel college
            = CollegesEditModel.Colleges.Single(x => (!x.IsNew && x.Id == CollegeEditModel.Id) || x.TemporaryId == CollegeEditModel.TemporaryId);

        college.Set(CollegeEditModel.College, CollegeEditModel.BeginYear, CollegeEditModel.EndYear);

        CollegeEditModel = new();

        EditMode = EditModeType.Add;
    }
}
