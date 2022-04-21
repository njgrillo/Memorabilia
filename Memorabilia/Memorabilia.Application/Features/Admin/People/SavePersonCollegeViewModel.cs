using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonCollegeViewModel : SaveViewModel
    {
        public SavePersonCollegeViewModel() { }

        public SavePersonCollegeViewModel(PersonCollege college)
        {
            BeginYear = college.BeginYear;
            CollegeId = college.CollegeId;
            EndYear = college.EndYear;
            Id = college.Id;
            PersonId = college.PersonId;
        }        

        public int? BeginYear { get; set; }

        public int CollegeId { get; set; }

        public string CollegeName => Domain.Constants.College.Find(CollegeId)?.Name;

        public Domain.Constants.College[] Colleges => Domain.Constants.College.All;

        public int? EndYear { get; set; }

        public int PersonId { get; set; }
    }
}
