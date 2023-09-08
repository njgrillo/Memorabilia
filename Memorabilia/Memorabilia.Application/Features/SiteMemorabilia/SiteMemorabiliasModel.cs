namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteMemorabiliasModel : Model
{
    public SiteMemorabiliasModel() { }

    public SiteMemorabiliasModel(IEnumerable<Entity.Memorabilia> memorabiliaItems,
                                 PageInfoResult pageInfo = null)
    {
        MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new SiteMemorabiliaModel(memorabiliaItem))
                                           .ToList();

        PageInfo = pageInfo;
    }

    public List<SiteMemorabiliaModel> MemorabiliaItems { get; set; }
        = new();

    public override string PageTitle
        => "Memorabilia";
}
