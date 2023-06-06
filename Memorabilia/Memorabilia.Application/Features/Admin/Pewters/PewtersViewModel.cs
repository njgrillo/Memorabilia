using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public class PewtersViewModel : Model
{
    public PewtersViewModel() { }

    public PewtersViewModel(IEnumerable<Pewter> pewters)
    {
        Pewters = pewters.Select(pewter => new PewterViewModel(pewter)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.Pewters.Item;

    public override string PageTitle => AdminDomainItem.Pewters.Title;

    public List<PewterViewModel> Pewters { get; set; } = new();

    public override string RoutePrefix => AdminDomainItem.Pewters.Page;
}
