namespace Memorabilia.Application.Features.Autograph;

public class AutographModel : Model
{
    private readonly Entity.Autograph _autograph;

    public AutographModel() { }

    public AutographModel(Entity.Autograph autograph)
    {
        _autograph = autograph;
    }

    public bool AcquiredWithAutograph 
        => _autograph.Memorabilia.Acquisition?.AcquiredWithAutograph ?? false;

    public Entity.Acquisition Acquisition 
        => _autograph.Acquisition;

    public DateTime? AcquisitionDate 
        => Acquisition?.AcquiredDate;

    public int AcquisitionTypeId 
        => Acquisition?.AcquisitionTypeId ?? 0;

    public string AcquisitionTypeName 
        => Constant.AcquisitionType.Find(Acquisition?.AcquisitionTypeId ?? 0)?.Name;        

    public List<Entity.AutographAuthentication> Authentications 
        => _autograph.Authentications;

    public string AuthenticationText 
        => Authentications.Count.ToString();

    public string AuthenticationTooltip 
        => $"{Authentications.Count} Authentication(s)";

    public string AutographImageName 
        => !PrimaryImageName.IsNullOrEmpty() 
           ? PrimaryImageName 
           : Constant.ImageFileName.ImageNotAvailable;    

    public int ColorId 
        => _autograph.ColorId;

    public string ColorName 
        => Constant.Color.Find(_autograph.ColorId)?.Name;

    public int ConditionId 
        => _autograph.ConditionId;

    public string ConditionName 
        => Constant.Condition.Find(_autograph.ConditionId)?.Name;

    public decimal? Cost 
        => Acquisition?.Cost;  

    public DateTime CreateDate 
        => _autograph.CreateDate;

    public int? Denominator 
        => _autograph.Denominator;

    public bool DisplaySpot 
        => Constant.ItemType.Find(ItemTypeId)?.CanHaveSpot() ?? false;

    public decimal? EstimatedValue 
        => _autograph.EstimatedValue;

    public string FormattedAcquisitionDate 
        => AcquisitionDate?.ToString("MM-dd-yyyy") ?? string.Empty;

    public string FormattedCost 
        => Acquisition?.Cost?.ToString("c") ?? string.Empty;

    public string FormattedEstimatedValue 
        => EstimatedValue?.ToString("c") ?? string.Empty;

    public bool? FullName 
        => _autograph.FullName;   

    public int? Grade 
        => _autograph.Grade;

    public int Id 
        => _autograph.Id;

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

    public List<Entity.AutographImage> Images 
        => _autograph.Images;        

    public string InscriptionText 
        => Inscriptions.Count.ToString();

    public string InscriptionTooltip
        => $"{Inscriptions.Count} Inscription(s)"; 

    public List<Entity.Inscription> Inscriptions 
        => _autograph.Inscriptions;

    public bool IsPersonalized 
        => Personalization?.Id > 0;

    public Constant.ItemType ItemType 
        => _autograph.Memorabilia.ItemType;

    public int ItemTypeId 
        => _autograph.Memorabilia.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(_autograph.Memorabilia.ItemTypeId)?.Name;

    public DateTime? LastModifiedDate 
        => _autograph.LastModifiedDate;

    public int MemorabiliaId 
        => _autograph.MemorabiliaId;

    public string[] MemorabiliaImageNames 
        => _autograph.Memorabilia
                     .Images
                     .Select(image => image.FileName)
                     .ToArray() ?? Array.Empty<string>();

    public string MemorabiliaPrimaryImageName
        => _autograph.Memorabilia.Images.Any()
            ? _autograph.Memorabilia.Images.SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName ?? Constant.ImageFileName.ImageNotAvailable
            : Constant.ImageFileName.ImageNotAvailable;

    public string Note 
        => _autograph.Note;

    public int? Numerator 
        => _autograph.Numerator;

    public Entity.Person Person 
        => _autograph.Person;

    public Entity.Personalization Personalization 
        => _autograph.Personalization;

    public string PersonalizationText 
        => IsPersonalized 
        ? "Personalized" 
        : "Not Personalized";

    public string PersonalizationTooltip 
        => IsPersonalized 
        ? _autograph.Personalization?.Text 
        : "Not Personalized";

    public int PersonId
        => _autograph.PersonId;

    public string PersonImageName
        => !_autograph.Person.ImageFileName.IsNullOrEmpty()
            ? Person.ImageFileName
            : Constant.ImageFileName.ImageNotAvailable;

    public string PersonName 
        => _autograph.Person?.DisplayName;

    public string PrimaryImageName 
        => Images.Any()
            ? Images.SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName ?? Constant.ImageFileName.ImageNotAvailable
            : Constant.ImageFileName.ImageNotAvailable;        

    public int? PurchaseTypeId 
        => _autograph?.Acquisition?.PurchaseTypeId;

    public string PurchaseTypeName 
        => Constant.PurchaseType.Find(PurchaseTypeId ?? 0)?.Name;

    public int? SpotId 
        => _autograph?.Spot?.SpotId;

    public int? ThroughTheMailId
        => _autograph.ThroughTheMailMemorabilia?.ThroughTheMailId;

    public string UserFirstName 
        => _autograph.Memorabilia.User.FirstName;

    public int UserId
        => _autograph.Memorabilia.UserId;

    public int WritingInstrumentId 
        => _autograph.WritingInstrumentId;

    public string WritingInstrumentName 
        => Constant.WritingInstrument.Find(_autograph.WritingInstrumentId)?.Name;
}
