namespace Memorabilia.Domain.SearchModels.Autographs;

public class AutographSearchCriteria : SearchCriteria
{
    public Constant.AuthenticationFilter AuthenticationFilter { get; set; } 
        = Constant.AuthenticationFilter.None;

    public string AuthenticationFilterName
        => AuthenticationFilter.Name;

    public IEnumerable<int> ColorIds { get; set; }
        = Enumerable.Empty<int>();

    public int? Grade { get; set; }

    public Constant.InscriptionFilter InscriptionFilter { get; set; } 
        = Constant.InscriptionFilter.None;

    public string InscriptionFilterName
        => InscriptionFilter.Name;

    public Constant.PersonalizationFilter PersonalizationFilter { get; set; } 
        = Constant.PersonalizationFilter.None;

    public string PersonalizationFilterName
        => PersonalizationFilter.Name;

    public IEnumerable<int> SpotIds { get; set; } 
        = Enumerable.Empty<int>();

    public IEnumerable<int> WritingInstrumentIds { get; set; } 
        = Enumerable.Empty<int>();
}
