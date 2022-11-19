using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaItemsViewModel : ViewModel
{
    public MemorabiliaItemsViewModel() { }

    public MemorabiliaItemsViewModel(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems, 
                                     PageInfoResult pageInfo = null)
    {
        MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new MemorabiliaItemViewModel(memorabiliaItem)).ToList();
        PageInfo = pageInfo;
    }

    public string AddRoute => $"Memorabilia/{EditModeType.Update.Name}";

    public string AddText => $"{EditModeType.Add.Name} Memorabilia";

    public List<MemorabiliaItemViewModel> MemorabiliaItems { get; set; } = new();

    public override string PageTitle => "Memorabilia";       
}
