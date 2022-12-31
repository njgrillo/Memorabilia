using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonDraftViewModel : SaveViewModel
{
    public SavePersonDraftViewModel() { }

    public SavePersonDraftViewModel(IEnumerable<int> sportIds)
    {
        Sports = sportIds.Select(sportId => Domain.Constants.Sport.Find(sportId)).ToArray();
    }

    public SavePersonDraftViewModel(Draft draft)
    {
        Franchise = Domain.Constants.Franchise.Find(draft.FranchiseId);
        Id = draft.Id;
        Overall = draft.Overall;
        PersonId = draft.PersonId;
        Pick = draft.Pick;
        Round = draft.Round;    
        Year = draft.Year;
    }

    public Domain.Constants.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;

    public int? Overall { get; set; }

    public int PersonId { get; set; }

    public int? Pick { get; set; }

    [Required]
    [Range(1, 50, ErrorMessage = "Round is required and must be 1 or greater.")]
    public int? Round { get; set; }

    public Domain.Constants.Sport[] Sports { get; set; } = Array.Empty<Domain.Constants.Sport>();

    [Required]
    [Range(1965, 3000, ErrorMessage = "Year is required and must be 1965 or later.")]
    public int? Year { get; set; }
}
