using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class SaveInscriptionsViewModel : SaveViewModel
{
    public SaveInscriptionsViewModel() { }

    public SaveInscriptionsViewModel(IEnumerable<Domain.Entities.Inscription> inscriptions, 
                                     int itemTypeId, 
                                     int memorabiliaId,
                                     int autographId)
    {
        Inscriptions = inscriptions.Select(inscription => new SaveInscriptionViewModel(new InscriptionViewModel(inscription))).ToList();
        ItemType = ItemType.Find(itemTypeId);
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
    }

    public int AutographId { get; set; }

    public AutographStep AutographStep => AutographStep.Inscription;

    public override string BackNavigationPath => $"Autographs/{EditModeType.Update.Name}/{MemorabiliaId}/{AutographId}";

    public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

    public override EditModeType EditModeType => Inscriptions.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public string ImagePath => AdminDomainItem.InscriptionTypes.ImagePath;

    public List<SaveInscriptionViewModel> Inscriptions { get; set; } = new();

    public ItemType ItemType { get; set; }

    public string ItemTypeName => ItemType.Find(ItemType.Id)?.Name;

    public int MemorabiliaId { get; }

    public override string PageTitle => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Inscription(s)";
}
