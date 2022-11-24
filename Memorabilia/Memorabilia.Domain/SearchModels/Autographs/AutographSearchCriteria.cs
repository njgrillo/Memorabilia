using Memorabilia.Domain.Constants;

namespace Memorabilia.Domain.SearchModels.Autographs;

public class AutographSearchCriteria : SearchCriteria
{
    public IEnumerable<int> ColorIds { get; set; } = Enumerable.Empty<int>();

    public int? Grade { get; set; }

    public AuthenticationFilter AuthenticationFilter { get; set; } = AuthenticationFilter.None;

    public InscriptionFilter InscriptionFilter { get; set; } = InscriptionFilter.None;

    public PersonalizationFilter PersonalizationFilter { get; set; } = PersonalizationFilter.None;

    public IEnumerable<int> SpotIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> WritingInstrumentIds { get; set; } = Enumerable.Empty<int>();
}
