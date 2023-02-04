using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class SaveInscriptionsViewModel : SaveViewModel
{
    public SaveInscriptionsViewModel() { }

    public SaveInscriptionsViewModel(IEnumerable<Domain.Entities.Inscription> inscriptions, 
                                     int itemTypeId, 
                                     int memorabiliaId,
                                     int autographId,
                                     string[] memorabiliaImageNames,
                                     int personId)
    {
        Inscriptions = inscriptions.Select(inscription => new SaveInscriptionViewModel(new InscriptionViewModel(inscription))).ToList();
        ItemType = ItemType.Find(itemTypeId);
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
        MemorabiliaImageNames = memorabiliaImageNames;
        PersonId = personId;
    }

    public int AutographId { get; set; }

    public AutographStep AutographStep => AutographStep.Inscription;

    public override string BackNavigationPath 
        => $"Autographs/{EditModeType.Update.Name}/{MemorabiliaId}/{AutographId}";

    public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

    public override string ContinueNavigationPath
        => $"Autographs/Authentications/{EditModeType.Update.Name}/{AutographId}";

    public override EditModeType EditModeType 
        => Inscriptions.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasMemorabiliaImages => MemorabiliaImageNames.Any();

    public string ImageFileName => AdminDomainItem.InscriptionTypes.ImageFileName;

    public List<SaveInscriptionViewModel> Inscriptions { get; set; } = new();

    public ItemType ItemType { get; set; }

    public int MemorabiliaId { get; }

    public string[] MemorabiliaImageNames { get; } = Array.Empty<string>();

    public override string PageTitle 
        => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Inscription(s)";

    public int PersonId { get; }
}
