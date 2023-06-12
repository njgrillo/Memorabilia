namespace Memorabilia.Domain.SearchModels.Autographs;

public class AutographSearchCriteria : SearchCriteria
{
    public IEnumerable<int> ColorIds { get; set; } 
        = Enumerable.Empty<int>();

    public int? Grade { get; set; }

    public Constant.AuthenticationFilter AuthenticationFilter { get; set; } 
        = Constant.AuthenticationFilter.None;

    public Constant.InscriptionFilter InscriptionFilter { get; set; } 
        = Constant.InscriptionFilter.None;

    public Constant.PersonalizationFilter PersonalizationFilter { get; set; } 
        = Constant.PersonalizationFilter.None;

    public IEnumerable<int> SpotIds { get; set; } 
        = Enumerable.Empty<int>();

    public IEnumerable<int> WritingInstrumentIds { get; set; } 
        = Enumerable.Empty<int>();
}
