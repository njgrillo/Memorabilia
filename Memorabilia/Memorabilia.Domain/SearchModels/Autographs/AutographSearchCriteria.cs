namespace Memorabilia.Domain.SearchModels.Autographs;

public class AutographSearchCriteria : SearchCriteria
{
    public IEnumerable<int> ColorIds { get; set; } = Enumerable.Empty<int>();

    public int? Grade { get; set; }

    public bool IsAuthenticated { get; set; }

    public bool IsInscribed { get; set; }

    public bool? IsPersonalized { get; set; }

    public IEnumerable<int> SpotIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> WritingInstrumentIds { get; set; } = Enumerable.Empty<int>();
}
