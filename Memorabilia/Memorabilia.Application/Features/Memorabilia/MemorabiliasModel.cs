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

    public string AddRoute 
        => $"Memorabilia/{Constant.EditModeType.Update.Name}";

    public string AddText 
        => $"{Constant.EditModeType.Add.Name} Memorabilia";

    public List<MemorabiliaModel> MemorabiliaItems { get; set; } 
        = new();

    public override string PageTitle 
        => "Memorabilia";       
}
