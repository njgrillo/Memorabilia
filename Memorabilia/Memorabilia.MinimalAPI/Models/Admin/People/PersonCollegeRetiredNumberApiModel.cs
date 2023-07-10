namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonCollegeRetiredNumberApiModel
{
    private readonly Entity.CollegeRetiredNumber _collegeRetiredNumber;

    public PersonCollegeRetiredNumberApiModel(Entity.CollegeRetiredNumber collegeRetiredNumber)
    {
        _collegeRetiredNumber = collegeRetiredNumber;
    }

    public string Name
        => Constant.College.Find(_collegeRetiredNumber.CollegeId).Name;

    public string Number
        => _collegeRetiredNumber.PlayerNumber.ToString();
}
