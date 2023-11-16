namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliasModel : Model
{
    public MemorabiliasModel() { }

    public MemorabiliasModel(IEnumerable<Entity.Memorabilia> memorabiliaItems, 
                             PageInfoResult pageInfo = null)
    {
        MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new MemorabiliaModel(memorabiliaItem))
                                           .ToList();

        PageInfo = pageInfo;
    }

    public List<MemorabiliaModel> MemorabiliaItems { get; set; } 
        = [];      
}
