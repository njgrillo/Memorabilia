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

    public bool HasImages { get; set; }

    public Person Person { get; set; }

    public IEnumerable<int> PurchaseTypeIds { get; set; } = Enumerable.Empty<int>();

    public Team Team { get; set; }
}
