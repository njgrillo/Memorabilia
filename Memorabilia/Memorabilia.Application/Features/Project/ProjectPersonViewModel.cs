using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Project
{
    public class ProjectPersonViewModel
    {
        private readonly ProjectPerson _projectPerson;

        public ProjectPersonViewModel() { }

        public ProjectPersonViewModel(ProjectPerson projectPerson)
        {
            _projectPerson = projectPerson;
        }

        public int Id => _projectPerson.Id;

        public Domain.Constants.ItemType ItemType => Domain.Constants.ItemType.Find(ItemTypeId ?? 0);

        public int? ItemTypeId => _projectPerson.ItemTypeId;

        public string ItemTypeName => ItemType?.Name;

        public Person Person => _projectPerson.Person;

        public int PersonId => _projectPerson.PersonId;

        public string PersonName => _projectPerson.Person.DisplayName;

        public int? PriorityTypeId => _projectPerson.PriorityTypeId;

        public string PriorityTypeName => Domain.Constants.PriorityType.Find(PriorityTypeId ?? 0)?.Name;

        public int? Rank => _projectPerson.Rank;

        public bool Upgrade => _projectPerson.Upgrade;
    }
}
