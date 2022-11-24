using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Domain.SearchModels;

public class SearchCriteria
{
    public DateTime? AcquiredDateBegin { get; set; }

    public DateTime? AcquiredDateEnd { get; set; }

    public IEnumerable<int> AcquisitionTypeIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> ConditionIds { get; set; } = Enumerable.Empty<int>();

    public decimal? CostHigh { get; set; }

    public decimal? CostLow { get; set; }

    public decimal? EstimatedValueHigh { get; set; }

    public decimal? EstimatedValueLow { get; set; }

    public IEnumerable<int> FranchiseIds { get; set; } = Enumerable.Empty<int>();

    public ImageFilter ImageFilter { get; set; } = ImageFilter.None;

    public List<Person> People { get; set; } = new();

    public int[] PersonIds => People.Select(person => person.Id).Distinct().ToArray();

    public IEnumerable<int> PurchaseTypeIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> SportIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> SportLeagueLevelIds { get; set; } = Enumerable.Empty<int>();

    public int[] TeamIds => Teams.Select(team => team.Id).Distinct().ToArray();

    public List<Team> Teams { get; set; } = new();
}
