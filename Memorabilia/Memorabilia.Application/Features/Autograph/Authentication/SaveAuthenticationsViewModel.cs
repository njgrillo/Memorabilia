using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Authentication;

public class SaveAuthenticationsViewModel : SaveViewModel
{
    public SaveAuthenticationsViewModel() { }

    public SaveAuthenticationsViewModel(IEnumerable<Domain.Entities.AutographAuthentication> authentications, 
                                        ItemType itemType, 
                                        int memorabiliaId,
                                        int autographId)
    {
        Authentications = authentications.Select(authentication => new SaveAuthenticationViewModel(new AuthenticationViewModel(authentication))).ToList();
        ItemType = itemType;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
    }

    public List<SaveAuthenticationViewModel> Authentications { get; set; } = new();

    public int AutographId { get; set; }

    public AutographStep AutographStep => AutographStep.Authentication;

    public override string BackNavigationPath => $"Autographs/Inscriptions/{EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

    public override string ContinueNavigationPath => CanHaveSpot
            ? $"Autographs/{AdminDomainItem.Spots.Item}/{EditModeType.Update.Name}/{AutographId}"
            : $"Autographs/Image/{EditModeType.Update.Name}/{AutographId}";

    public override EditModeType EditModeType => Authentications.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public string ImageFileName => AdminDomainItem.AuthenticationCompanies.ImageFileName;

    public ItemType ItemType { get; }

    public string ItemTypeName => ItemType.Find(ItemType.Id)?.Name;

    public int MemorabiliaId { get; }

    public override string PageTitle => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Authentication(s)";
}
