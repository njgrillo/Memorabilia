using Memorabilia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonDraftViewModel : SaveViewModel
    {
        public SavePersonDraftViewModel() { }

        public SavePersonDraftViewModel(IEnumerable<int> sportIds)
        {
            SportIds = sportIds.ToArray();
        }

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

        public Domain.Constants.Franchise[] Franchises => Domain.Constants.Franchise.GetAll(SportIds);

        public int? Overall { get; set; }

        public int PersonId { get; set; }

        public int? Pick { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Round is required and must be 1 or greater.")]
        public int? Round { get; set; }

        public int[] SportIds { get; set; } = Array.Empty<int>();

        [Required]
        [Range(1965, 3000, ErrorMessage = "Year is required and must be 1965 or later.")]
        public int? Year { get; set; }
    }
}
