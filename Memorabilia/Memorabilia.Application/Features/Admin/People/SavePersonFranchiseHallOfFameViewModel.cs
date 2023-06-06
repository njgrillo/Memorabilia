using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonFranchiseHallOfFameViewModel : EditModel
{
    public SavePersonFranchiseHallOfFameViewModel() { }

    public SavePersonFranchiseHallOfFameViewModel(FranchiseHallOfFame hof)
    {
        FranchiseHallOfFameType = Constant.FranchiseHallOfFameType.Find(hof.FranchiseId);
        Id = hof.Id;
        PersonId = hof.PersonId;
        Year = hof.Year;
    }

    public Constant.FranchiseHallOfFameType FranchiseHallOfFameType { get; set; }

    public string FranchiseHallOfFameTypeName => FranchiseHallOfFameType?.Name;

    public string FranchiseName => FranchiseHallOfFameType?.Franchise?.Name;

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
