using Memorabilia.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonDraftViewModel : SaveViewModel
    {
        public SavePersonDraftViewModel() { }

        public SavePersonDraftViewModel(Draft draft)
        {
            FranchiseId = draft.FranchiseId;
            Id = draft.Id;
            Overall = draft.Overall;
            PersonId = draft.PersonId;
            Pick = draft.Pick;
            Round = draft.Round;    
            Year = draft.Year;
        }

        public int FranchiseId { get; set; }

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

        public Domain.Constants.Franchise[] Franchises => Domain.Constants.Franchise.All;

        public int? Overall { get; set; }

        public int PersonId { get; set; }

        public int? Pick { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Round is required and must be 1 or greater.")]
        public int? Round { get; set; }

        [Required]
        [Range(1965, 3000, ErrorMessage = "Year is required and must be 1965 or later.")]
        public int? Year { get; set; }
    }
}
