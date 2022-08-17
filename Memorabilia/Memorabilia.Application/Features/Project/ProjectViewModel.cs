using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Project
{
    public class ProjectViewModel
    {
        private readonly Domain.Entities.Project _project;

        public ProjectViewModel() { }

        public ProjectViewModel(Domain.Entities.Project project)
        {
            _project = project;
            People = _project.People.Select(person => new ProjectPersonViewModel(person)).ToList();
        }

        public DateTime? EndDate => _project.EndDate;

        public string FormattedEndDate => EndDate?.ToString("MM/dd/yyyy");

        public string FormattedStartDate => StartDate?.ToString("MM/dd/yyyy");

        public int Id => _project.Id;

        public string Name => _project.Name;

        public List<ProjectPersonViewModel> People { get; set; } = new();

        public DateTime? StartDate => _project.StartDate;

        public int UserId => _project.UserId;
    }
}
