namespace Memorabilia.Application.Features.Admin.Colleges.Management.RetiredNumbers;

public class CollegeRetiredNumbersEditModel : EditModel
{
    public CollegeRetiredNumbersEditModel() { }

    public CollegeRetiredNumbersEditModel(Entity.College college)
    {
        College = Constant.College.Find(college.Id);

        RetiredNumbers
            = college.RetiredNumbers
                     .Select(record => new CollegeRetiredNumberEditModel(record))
                     .ToList();
    }

    public Constant.College College { get; private set; }

    public List<CollegeRetiredNumberEditModel> RetiredNumbers { get; set; }
        = [];
}
