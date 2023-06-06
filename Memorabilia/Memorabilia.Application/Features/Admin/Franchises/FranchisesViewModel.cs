using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Franchises;

public class FranchisesViewModel : Model
{
    public FranchisesViewModel() { }

    public FranchisesViewModel(IEnumerable<Domain.Entities.Franchise> franchises)
    {
        Franchises = franchises.Select(franchise => new FranchiseViewModel(franchise))
                               .OrderBy(franchise => franchise.SportLeagueLevelName)
                               .ThenBy(franchise => franchise.Name)
                               .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<FranchiseViewModel> Franchises { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.Franchises.Item;

    public override string PageTitle => AdminDomainItem.Franchises.Title;

    public override string RoutePrefix => AdminDomainItem.Franchises.Page;
}
