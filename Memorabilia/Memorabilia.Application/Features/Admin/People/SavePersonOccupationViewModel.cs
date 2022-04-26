using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonOccupationViewModel : SaveViewModel
    {
        public SavePersonOccupationViewModel() { }

        public SavePersonOccupationViewModel(PersonOccupationViewModel occupation)
        {
            Id = occupation.Id;
            OccupationId = occupation.OccupationId;
            OccupationTypeId = occupation.OccupationTypeId;
        }

        [Required]
        public int OccupationId { get; set; }

        public string OccupationName => Domain.Constants.Occupation.Find(OccupationId)?.Name;

        public Domain.Constants.Occupation[] Occupations => Domain.Constants.Occupation.All;

        [Required]
        public int OccupationTypeId { get; set; }

        public string OccupationTypeName => Domain.Constants.OccupationType.Find(OccupationTypeId)?.Name;

        public Domain.Constants.OccupationType[] OccupationTypes => Domain.Constants.OccupationType.All;
    }
}
