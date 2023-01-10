using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCollegeRetiredNumberViewModel : SaveViewModel
{
    public SavePersonCollegeRetiredNumberViewModel() { }

    public SavePersonCollegeRetiredNumberViewModel(CollegeRetiredNumber collegeRetiredNumber)
    {
        College = Domain.Constants.College.Find(collegeRetiredNumber.CollegeId);
        Id = collegeRetiredNumber.Id;
        PersonId = collegeRetiredNumber.PersonId;
        PlayerNumber = collegeRetiredNumber.PlayerNumber;
    }

    public Domain.Constants.College College { get; set; }

    public string CollegeName => College?.Name;

    public int PersonId { get; set; }

    [Required]
    [Range(0, 99, ErrorMessage = "Number is required and must be 0 or greater.")]
    public int? PlayerNumber { get; set; }
}
