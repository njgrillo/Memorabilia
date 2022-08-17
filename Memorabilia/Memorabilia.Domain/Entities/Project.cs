using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Project : Framework.Domain.Entity.DomainEntity
    {
        public Project() { }

        public Project(string name, DateTime? startDate, DateTime? endDate, int userId)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            UserId = userId;
        }

        public DateTime? EndDate { get; set; }

        public string Name { get; set; }

        public virtual List<ProjectPerson> People { get; set; }

        public DateTime? StartDate { get; set; }

        public int UserId { get; set; }

        public void RemovePeople(params int[] personIds)
        {
            if (personIds == null || personIds.Length == 0)
                return;

            People.RemoveAll(person => personIds.Contains(person.Id));
        }

        public void Set(string name, DateTime? startDate, DateTime? endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetPerson(int id, int personId, int? itemTypeId, bool upgrade, int? rank, int? priorityTypeId)
        {
            var person = id > 0 
                ? People.SingleOrDefault(person => person.Id == id)
                : People.SingleOrDefault(person => person.PersonId == personId && person.ItemTypeId == itemTypeId);

            if (person == null)
            {
                People.Add(new ProjectPerson(Id, personId, itemTypeId, upgrade, rank, priorityTypeId));
                return;
            }

            person.Set(personId, itemTypeId, upgrade, rank, priorityTypeId);
        }
    }
}
