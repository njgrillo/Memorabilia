using Memorabilia.Domain.Entities;

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

        public int Round { get; set; }

        public int Year { get; set; }
    }
}
