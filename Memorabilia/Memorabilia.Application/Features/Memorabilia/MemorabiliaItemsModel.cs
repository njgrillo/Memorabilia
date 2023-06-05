namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaItemsModel : ViewModel
{
    public MemorabiliaItemsModel() { }

    public MemorabiliaItemsModel(IEnumerable<Entity.Memorabilia> memorabiliaItems, 
                                     PageInfoResult pageInfo = null)
    {
        MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new MemorabiliaItemModel(memorabiliaItem)).ToList();
        PageInfo = pageInfo;
    }

    public string AddRoute => $"Memorabilia/{Constant.EditModeType.Update.Name}";

    public string AddText => $"{Constant.EditModeType.Add.Name} Memorabilia";

    public List<MemorabiliaItemModel> MemorabiliaItems { get; set; } = new();

    public override string PageTitle => "Memorabilia";       
}
