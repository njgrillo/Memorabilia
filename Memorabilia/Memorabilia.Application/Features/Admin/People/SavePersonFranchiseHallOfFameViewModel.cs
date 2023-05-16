using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonFranchiseHallOfFameViewModel : SaveViewModel
{
    public SavePersonFranchiseHallOfFameViewModel() { }

    public SavePersonFranchiseHallOfFameViewModel(FranchiseHallOfFame hof)
    {
        FranchiseHallOfFameType = Domain.Constants.FranchiseHallOfFameType.Find(hof.FranchiseId);
        Id = hof.Id;
        PersonId = hof.PersonId;
        Year = hof.Year;
    }

    public Domain.Constants.FranchiseHallOfFameType FranchiseHallOfFameType { get; set; }

    public string FranchiseHallOfFameTypeName => FranchiseHallOfFameType?.Name;

    public string FranchiseName => FranchiseHallOfFameType?.Franchise?.Name;

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
