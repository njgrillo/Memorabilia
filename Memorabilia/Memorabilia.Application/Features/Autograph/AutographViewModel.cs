using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph;

public class AutographViewModel : ViewModel
{
    private readonly Domain.Entities.Autograph _autograph;

    public AutographViewModel() { }

    public AutographViewModel(Domain.Entities.Autograph autograph)
    {
        _autograph = autograph;
    }

    public bool AcquiredWithAutograph => _autograph.Memorabilia.Acquisition?.AcquiredWithAutograph ?? false;

    public Domain.Entities.Acquisition Acquisition => _autograph.Acquisition;

    public DateTime? AcquisitionDate => Acquisition?.AcquiredDate;

    public int AcquisitionTypeId => Acquisition?.AcquisitionTypeId ?? 0;

    public string AcquisitionTypeName => AcquisitionType.Find(Acquisition?.AcquisitionTypeId ?? 0)?.Name;        

    public List<Domain.Entities.AutographAuthentication> Authentications => _autograph.Authentications;

    public string AuthenticationText => Authentications.Any() ? "Has Authentication(s)" : "No Authentication(s)";

    public string AuthenticationTooltip => $"{Authentications.Count} Authentication(s)";

    public string AutographImagePath
    {
        get
        {
            if (PrimaryImagePath.IsNullOrEmpty() || !File.Exists(PrimaryImagePath))
                return ImagePath.ImageNotAvailable;

            return $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(PrimaryImagePath))}";
        }
    }

    public int ColorId => _autograph.ColorId;

    public string ColorName => Color.Find(_autograph.ColorId)?.Name;

    public int ConditionId => _autograph.ConditionId;

    public string ConditionName => Condition.Find(_autograph.ConditionId)?.Name;

    public decimal? Cost => Acquisition?.Cost;  

    public DateTime CreateDate => _autograph.CreateDate;

    public int? Denominator => _autograph.Denominator;

    public bool DisplaySpot => ItemType.CanHaveSpot(ItemType.Find(ItemTypeId));

    public decimal? EstimatedValue => _autograph.EstimatedValue;

    public string FormattedAcquisitionDate => AcquisitionDate?.ToString("MM-dd-yyyy") ?? string.Empty;

    public string FormattedCost => Acquisition?.Cost?.ToString("c") ?? string.Empty;

    public string FormattedEstimatedValue => EstimatedValue?.ToString("c") ?? string.Empty;

    public bool? FullName => _autograph.FullName;   

    public int? Grade => _autograph.Grade;

    public int Id => _autograph.Id;

    public string ImageDisplayCount
    {
        get
        {
            if (!Images.Any())
                return "No Images Found";

            if (Images.Count == 1)
                return "1 Image";

            return $"{Images.Count} Images";
        }
    }

    public List<Domain.Entities.AutographImage> Images => _autograph.Images;        

    public string InscriptionText => Inscriptions.Any() ? "Has Inscription(s)" : "No Inscription(s)";

    public string InscriptionTooltip => $"{Inscriptions.Count} Inscription(s)"; 

    public List<Domain.Entities.Inscription> Inscriptions => _autograph.Inscriptions;

    public bool IsPersonalized => Personalization?.Id > 0;

    public ItemType ItemType => _autograph.Memorabilia.ItemType;

    public int ItemTypeId => _autograph.Memorabilia.ItemTypeId;

    public string ItemTypeName => ItemType.Find(_autograph.Memorabilia.ItemTypeId)?.Name;

    public DateTime? LastModifiedDate => _autograph.LastModifiedDate;

    public int MemorabiliaId => _autograph.MemorabiliaId;

    public string Note => _autograph.Note;

    public int? Numerator => _autograph.Numerator;

    public Domain.Entities.Person Person => _autograph.Person;

    public Domain.Entities.Personalization Personalization => _autograph.Personalization;

    public string PersonalizationText => IsPersonalized ? "Personalized" : "Not Personalized";

    public string PersonalizationTooltip => IsPersonalized ? _autograph.Personalization?.Text : "Not Personalized";

    public int PersonId => _autograph.PersonId;

    public string PersonName => _autograph.Person?.DisplayName;

    public string PrimaryImagePath => Images.Any()
        ? Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FilePath ?? ImagePath.ImageNotAvailable
        : ImagePath.ImageNotAvailable;        

    public int? PurchaseTypeId => _autograph?.Acquisition?.PurchaseTypeId;

    public string PurchaseTypeName => PurchaseType.Find(PurchaseTypeId ?? 0)?.Name;

    public DateTime? ReceivedDate => _autograph.ThroughTheMail?.ReceivedDate;

    public DateTime? SentDate => _autograph.ThroughTheMail?.SentDate;

    public int? SpotId => _autograph?.Spot?.SpotId;

    public string UserFirstName => _autograph.Memorabilia.User.FirstName;

    public int WritingInstrumentId => _autograph.WritingInstrumentId;

    public string WritingInstrumentName => WritingInstrument.Find(_autograph.WritingInstrumentId)?.Name;
}
