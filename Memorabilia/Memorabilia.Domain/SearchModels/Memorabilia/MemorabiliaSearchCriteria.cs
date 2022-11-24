namespace Memorabilia.Domain.SearchModels.Memorabilia;

public class MemorabiliaSearchCriteria : SearchCriteria
{
    public AutographSearchCriteria AutographSearchCriteria { get; set; } = new();

    public IEnumerable<int> BrandIds { get; set; } = Enumerable.Empty<int>();    

    public IEnumerable<int> GameStyleTypeIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> ItemTypeIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> LevelTypeIds { get; set; } = Enumerable.Empty<int>();      

    public IEnumerable<int> PrivacyTypeIds { get; set; } = Enumerable.Empty<int>();

    public IEnumerable<int> SizeIds { get; set; } = Enumerable.Empty<int>();       
}
