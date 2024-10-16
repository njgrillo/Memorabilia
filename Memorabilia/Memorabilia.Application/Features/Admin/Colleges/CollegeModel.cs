namespace Memorabilia.Application.Features.Admin.Colleges;

public class CollegeModel
{
    private readonly Entity.College _college;

    public CollegeModel() { }

    public CollegeModel(Entity.College college)
    {
        _college = college;
    }

    public string Abbreviation 
        => _college.Abbreviation;

    public int Id
        => _college.Id;

    public string Name
        => _college.Name;
}
