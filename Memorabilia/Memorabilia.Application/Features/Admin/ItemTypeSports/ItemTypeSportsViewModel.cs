using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportsViewModel : ViewModel
{
    public ItemTypeSportsViewModel() { }

    public ItemTypeSportsViewModel(IEnumerable<ItemTypeSport> itemTypeSports)
    {
        ItemTypeSports = itemTypeSports.Select(itemTypeSport => new ItemTypeSportViewModel(itemTypeSport)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSportViewModel> ItemTypeSports { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeSports.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeSports.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSports.Page;
}
