namespace Memorabilia.Application.Features.Admin.Colleges.Management.RetiredNumbers;

public class CollegeRetiredNumbersViewModel : Model
{
    public CollegeRetiredNumbersViewModel() { }

    public CollegeRetiredNumbersViewModel(
        IEnumerable<Entity.College> colleges,
        PageInfoResult pageInfo
        )
    {
        Colleges
            = colleges.Select(college => new CollegeRetiredNumberViewModel(college))
                      .ToList();

        PageInfo = pageInfo;
    }

    public List<CollegeRetiredNumberViewModel> Colleges { get; set; }
        = [];
}
