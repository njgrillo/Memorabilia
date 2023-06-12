namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeRetiredNumberEditor
{
    [Parameter]
    public List<PersonCollegeRetiredNumberEditModel> CollegeRetiredNumbers { get; set; } 
        = new();

    [Parameter]
    public College[] Colleges { get; set; }

    protected PersonCollegeRetiredNumberEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditCollege 
        = true;

    private bool _canUpdate;    

    private void Add()
    {
        if (Model.College == null || !Model.PlayerNumber.HasValue)
            return;

        CollegeRetiredNumbers.Add(Model);

        Model = new PersonCollegeRetiredNumberEditModel();
    }

    private void Edit(PersonCollegeRetiredNumberEditModel CollegeRetiredNumber)
    {
        Model.College = CollegeRetiredNumber.College;
        Model.PlayerNumber = CollegeRetiredNumber.PlayerNumber;

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonCollegeRetiredNumberEditModel number 
            = CollegeRetiredNumbers.Single(number => number.College.Id == Model.College.Id);

        number.College = Model.College;
        number.PlayerNumber = Model.PlayerNumber;

        Model = new();

        _canAdd = true;
        _canEditCollege = true;
        _canUpdate = false;
    }
}
