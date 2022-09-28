using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonSingleSeasonRecordViewModel : SaveViewModel
    {
        public SavePersonSingleSeasonRecordViewModel() { }

        public SavePersonSingleSeasonRecordViewModel(SingleSeasonRecord record)
        {
            Amount = record.Amount;
            Id = record.Id;
            PersonId = record.PersonId;
            RecordTypeId = record.RecordTypeId;
            Year = record.Year;
        }

        public decimal? Amount { get; set; }

        public string DisplayAmount => Amount?.ToString("G29");

        public int PersonId { get; set; }

        public int RecordTypeId { get; set; }

        public string RecordTypeName => Domain.Constants.RecordType.Find(RecordTypeId)?.Name;

        public Domain.Constants.RecordType[] RecordTypes => Domain.Constants.RecordType.All;

        [Required]
        [Range(1800, 3000, ErrorMessage = "Year is required and must be 1800 or greater.")]
        public int? Year { get; set; }
    }
}
