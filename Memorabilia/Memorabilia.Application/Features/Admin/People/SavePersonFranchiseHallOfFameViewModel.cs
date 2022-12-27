using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonFranchiseHallOfFameViewModel : SaveViewModel
{
    public SavePersonFranchiseHallOfFameViewModel() { }

    public SavePersonFranchiseHallOfFameViewModel(FranchiseHallOfFame hof)
    {
        FranchiseId = hof.FranchiseId;
        Id = hof.Id;
        PersonId = hof.PersonId;
        Year = hof.Year;
    }

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
