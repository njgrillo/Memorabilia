using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonRetiredNumberViewModel : SaveViewModel
{
    public SavePersonRetiredNumberViewModel() { }

    public SavePersonRetiredNumberViewModel(RetiredNumber retiredNumber)
    {
        Franchise = Domain.Constants.Franchise.Find(retiredNumber.FranchiseId);
        Id = retiredNumber.Id;
        PersonId = retiredNumber.PersonId;
        PlayerNumber = retiredNumber.PlayerNumber;
    }

    public Domain.Constants.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;    

    public int PersonId { get; set; }

    [Required]
    [Range(0, 99, ErrorMessage = "Number is required and must be 0 or greater.")]
    public int? PlayerNumber { get; set; }
}
