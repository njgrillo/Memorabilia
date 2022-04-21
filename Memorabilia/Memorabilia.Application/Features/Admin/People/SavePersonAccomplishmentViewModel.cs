using Memorabilia.Domain.Entities;
using System;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonAccomplishmentViewModel : SaveViewModel
    {
        public SavePersonAccomplishmentViewModel() { }

        public SavePersonAccomplishmentViewModel(PersonAccomplishment accomplishment)
        {
            AccomplishmentTypeId = accomplishment.AccomplishmentTypeId;
            Date = accomplishment.Date;
            Id = accomplishment.Id;
            PersonId = accomplishment.PersonId;
            Year = accomplishment.Year;
        }

        public int AccomplishmentTypeId { get; set; }

        public string AccomplishmentTypeName => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId)?.Name;

        public Domain.Constants.AccomplishmentType[] AccomplishmentTypes => Domain.Constants.AccomplishmentType.All;

        public DateTime? Date { get; set; }

        public int PersonId { get; set; }

        public int? Year { get; set; }
    }
}
