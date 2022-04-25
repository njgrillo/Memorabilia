using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonCollegeEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonCollegeViewModel> Colleges { get; set; } = new();

        private SavePersonCollegeViewModel _viewModel = new();

        private void Add()
        {
            Colleges.Add(_viewModel);

            _viewModel = new SavePersonCollegeViewModel();
        }

        private void Remove(int collegeId)
        {
            var college = Colleges.SingleOrDefault(college => college.CollegeId == collegeId);

            if (college == null)
                return;

            college.IsDeleted = true;
        }
    }
}
