﻿namespace Memorabilia.Application.Features.Autograph.Authentication;

public class AuthenticationsEditModel : SaveViewModel
{
    public AuthenticationsEditModel() { }

    public AuthenticationsEditModel(IEnumerable<Entity.AutographAuthentication> authentications, 
                                    Constant.ItemType itemType, 
                                    int memorabiliaId,
                                    int autographId,
                                    string[] memorabiliaImageNames)
    {
        Authentications = authentications.Select(authentication => new AuthenticationEditModel(new AuthenticationModel(authentication)))
                                         .ToList();
        ItemType = itemType;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
        MemorabiliaImageNames = memorabiliaImageNames;
    }

    public List<AuthenticationEditModel> Authentications { get; set; } = new();

    public int AutographId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Authentication;

    public override string BackNavigationPath 
        => $"Autographs/Inscriptions/{Constant.EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot 
        => ItemType.CanHaveSpot();

    public override string ContinueNavigationPath 
        => CanHaveSpot
            ? $"Autographs/{Constant.AdminDomainItem.Spots.Item}/{Constant.EditModeType.Update.Name}/{AutographId}"
            : $"Autographs/Image/{Constant.EditModeType.Update.Name}/{AutographId}";

    public override Constant.EditModeType EditModeType 
        => Authentications.Any() ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/Items";

    public bool HasMemorabiliaImages 
        => MemorabiliaImageNames.Any();

    public string ImageFileName 
        => Constant.AdminDomainItem.AuthenticationCompanies.ImageFileName;

    public Constant.ItemType ItemType { get; }

    public int MemorabiliaId { get; }

    public string[] MemorabiliaImageNames { get; } = Array.Empty<string>();

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Add ? Constant.EditModeType.Add.Name : Constant.EditModeType.Update.Name)} Authentication(s)";
}
