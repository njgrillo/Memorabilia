using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Sports;

public class SportsViewModel : ViewModel
{
    public SportsViewModel() { }

    public SportsViewModel(IEnumerable<Domain.Entities.Sport> sports) 
    {
        Sports = sports.Select(sport => new SportViewModel(sport)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.Sports.Item;

    public override string PageTitle => AdminDomainItem.Sports.Title;

    public override string RoutePrefix => AdminDomainItem.Sports.Page;

    public List<SportViewModel> Sports { get; set; } = new();
}
