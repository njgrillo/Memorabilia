namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteMemorabiliaModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public SiteMemorabiliaModel() { }

    public SiteMemorabiliaModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.Acquisition Acquisition
        => _memorabilia.MemorabiliaAcquisition.Acquisition;

    public string AcquisitionTypeName
        => Constant.AcquisitionType.Find(_memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId).Name;

    public bool AllowBestOffer
        => _memorabilia.ForSale?.AllowBestOffer ?? false;

    public List<AutographModel> Autographs
        => _memorabilia.Autographs
                       .Select(autograph => new AutographModel(autograph))
                       .ToList();

    public int AutographsCount
        => _memorabilia.Autographs.Count;

    public string AutographDisplayCount
        => $"{AutographsCount} Autograph(s)";

    public int? BrandId
        => _memorabilia.Brand?.BrandId;

    public decimal? BuyNowPrice
        => _memorabilia.ForSale?.BuyNowPrice;

    public List<Entity.Collection> Collections
        => _memorabilia.CollectionMemorabilias?
                       .Select(item => item.Collection)
                       .ToList() ?? [];

    public int? ConditionId
        => _memorabilia.ConditionId;

    public string ConditionName
        => _memorabilia.Condition?.Name;

    public DateTime CreateDate
        => _memorabilia.CreateDate;

    public bool DisplayAutographDetails { get; set; }

    public int? Denominator
        => _memorabilia.Denominator;

    public decimal? EstimatedValue
        => _memorabilia.EstimatedValue;

    public string FormattedCreateDate
        => CreateDate.ToString("MM-dd-yyyy");

    public string FormattedLastModifiedDate
        => LastModifiedDate?.ToString("MM-dd-yyyy");

    public string FormattedTotalCost
        => ((Acquisition?.Cost ?? 0) + _memorabilia.Autographs
                                                   .Sum(autograph => autograph.Acquisition?.Cost ?? 0))
                                                   .ToString("c");

    public string FormattedTotalValue
        => ((EstimatedValue ?? 0) + _memorabilia.Autographs
                                                .Sum(autograph => autograph.EstimatedValue ?? 0))
                                                .ToString("c");

    public bool ForTrade
        => _memorabilia.ForTrade;

    public bool Framed
        => _memorabilia.Framed;

    public IEnumerable<Entity.Franchise> Franchises
        => Teams.Select(team => team.Team.Franchise);

    public int? GameStyleTypeId
        => _memorabilia.Game?.GameStyleTypeId;

    public bool HasAutographs
        => _memorabilia.Autographs.Count != 0;

    public int Id
        => _memorabilia.Id;

    public string ImageDisplayCount
    {
        get
        {
            if (Images.IsNullOrEmpty())
                return "No Images Found";

            if (Images.Count == 1)
                return "1 Image";

            return $"{Images.Count} Images";
        }
    }

    public string ImageFileName
        => _memorabilia.Images.IsNullOrEmpty()
        ? Constant.ImageFileName.ImageNotAvailable
        : _memorabilia.Images
                      .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                      .FileName ?? _memorabilia.Images.First().FileName;

    public List<Entity.MemorabiliaImage> Images
        => _memorabilia.Images;

    public bool IsForSale
        => (_memorabilia.ForSale?.BuyNowPrice.HasValue ?? false) || 
           (_memorabilia.ForSale?.AllowBestOffer ?? false);

    public int ItemTypeId
        => _memorabilia.ItemTypeId;

    public string ItemTypeName
        => _memorabilia.ItemType?.Name;

    public DateTime? LastModifiedDate
        => _memorabilia.LastModifiedDate;

    public int? LevelTypeId
        => _memorabilia.LevelType?.Id;

    public Entity.Memorabilia Memorabilia
        => _memorabilia;

    public string Note
        => _memorabilia.Note;

    public int? Numerator
        => _memorabilia.Numerator;

    public IEnumerable<Entity.MemorabiliaPerson> People
        => _memorabilia.People;

    public int? PrimaryAutographId
        => _memorabilia.Autographs.FirstOrDefault()?.Id;

    public string PrimaryAutographImageName
        => HasAutographs
            ? _memorabilia.Autographs
                          .SelectMany(autograph => autograph.Images)
                          .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                          .FileName ?? Constant.ImageFileName.ImageNotAvailable
            : Constant.ImageFileName.ImageNotAvailable;

    public int PrivacyTypeId
        => _memorabilia.PrivacyTypeId;

    public string PrivacyTypeName
        => Constant.PrivacyType.Find(_memorabilia.PrivacyTypeId).Name;

    public int? PurchaseTypeId
        => _memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId;

    public string PurchaseTypeName
        => Constant.PurchaseType
                   .Find(_memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId ?? 0)?
                   .Name;

    public int? SizeId
        => _memorabilia.Size?.SizeId;

    public IEnumerable<Entity.SportLeagueLevel> SportLeagueLevels
        => Franchises.Select(franchise => franchise.SportLeagueLevel);

    public IEnumerable<Entity.MemorabiliaSport> Sports
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams
        => _memorabilia.Teams;

    public int[] ThroughTheMailIds
        => _memorabilia.ThroughTheMailMemorabilias
                       .Select(item => item.ThroughTheMailId)
                       .ToArray();

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public string UserFirstName
        => _memorabilia.User.FirstName;

    public int UserId
        => _memorabilia.UserId;
}
