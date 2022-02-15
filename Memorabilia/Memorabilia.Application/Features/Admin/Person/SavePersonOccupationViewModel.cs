namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonOccupationViewModel : SaveViewModel
    {
        public SavePersonOccupationViewModel() { }

        public SavePersonOccupationViewModel(Domain.Entities.PersonOccupation occupation)
        {
            Id = occupation.Id;
            OccupationId = occupation.OccupationId;
            OccupationTypeId = occupation.OccupationTypeId;
        }

        public int OccupationId { get; set; }

        public string OccupationName => Domain.Constants.Occupation.Find(OccupationId)?.Name;

        public int OccupationTypeId { get; set; }

        public string OccupationTypeName => Domain.Constants.OccupationType.Find(OccupationTypeId)?.Name;
    }
}
