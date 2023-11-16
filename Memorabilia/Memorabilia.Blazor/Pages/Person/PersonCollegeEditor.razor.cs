namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeEditor
{
    [Parameter]
    public List<PersonCollegeEditModel> Colleges { get; set; } 
        = [];

    protected PersonCollegeEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.College == null)
            return;

        Colleges.Add(Model);

        Model = new PersonCollegeEditModel();
    }

    private void Edit(PersonCollegeEditModel college)
    {
        Model.College = college.College;
        Model.BeginYear = college.BeginYear;
        Model.EndYear = college.EndYear;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonCollegeEditModel college 
            = Colleges.Single(college => college.College.Id == Model.College.Id);

        college.College = Model.College;
        college.BeginYear = Model.BeginYear;
        college.EndYear = Model.EndYear;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
