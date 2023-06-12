namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeEditor
{
    [Parameter]
    public List<PersonCollegeEditModel> Colleges { get; set; } 
        = new();

    protected PersonCollegeEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditCollege 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonCollegeEditModel college = Colleges.Single(college => college.College.Id == Model.College.Id);

        college.College = Model.College;
        college.BeginYear = Model.BeginYear;
        college.EndYear = Model.EndYear;

        Model = new();

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }
}
