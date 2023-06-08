namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionsEditModel : EditModel
{
    public InscriptionsEditModel() { }

    public InscriptionsEditModel(IEnumerable<Entity.Inscription> inscriptions, 
                                 int itemTypeId, 
                                 int userId,
                                 int memorabiliaId,
                                 int autographId,
                                 string[] memorabiliaImageNames,
                                 int personId)
    {
        Inscriptions = inscriptions.Select(inscription => new InscriptionEditModel(new InscriptionModel(inscription)))
                                   .ToList();
        ItemType = Constant.ItemType.Find(itemTypeId);
        UserId = userId;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
        MemorabiliaImageNames = memorabiliaImageNames;
        PersonId = personId;
    }

    public int AutographId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Inscription;

    public override string BackNavigationPath 
        => $"Autographs/{Constant.EditModeType.Update.Name}/{MemorabiliaId}/{AutographId}";

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public override string ContinueNavigationPath
        => $"Autographs/Authentications/{Constant.EditModeType.Update.Name}/{AutographId}";

    public override Constant.EditModeType EditModeType 
        => Inscriptions.Any() ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public bool HasMemorabiliaImages 
        => MemorabiliaImageNames.Any();

    public string ImageFileName
        => Constant.AdminDomainItem.InscriptionTypes.ImageFileName;

    public List<InscriptionEditModel> Inscriptions { get; set; } = new();

    public Constant.ItemType ItemType { get; set; }

    public int MemorabiliaId { get; }

    public string[] MemorabiliaImageNames { get; } = Array.Empty<string>();

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Add ? Constant.EditModeType.Add.Name : Constant.EditModeType.Update.Name)} Inscription(s)";

    public int PersonId { get; }

    public int UserId { get; }
}
