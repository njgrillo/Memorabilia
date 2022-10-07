using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Divisions;

public class DivisionsViewModel : ViewModel
{
    public DivisionsViewModel() { }

    public DivisionsViewModel(IEnumerable<Domain.Entities.Division> divisions)
    {
        Divisions = divisions.Select(division => new DivisionViewModel(division))
                             .OrderBy(division => division.Name)
                             .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<DivisionViewModel> Divisions { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.Divisions.Item;

    public override string PageTitle => AdminDomainItem.Divisions.Title;

    public override string RoutePrefix => AdminDomainItem.Divisions.Page;
}
