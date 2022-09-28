using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class MemorabiliaItemViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public MemorabiliaItemViewModel() { }

        public MemorabiliaItemViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public Acquisition Acquisition => _memorabilia.MemorabiliaAcquisition.Acquisition;

        public string AcquisitionTypeName => Domain.Constants.AcquisitionType.Find(_memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId).Name;

        public List<AutographViewModel> Autographs => _memorabilia.Autographs.Select(autograph => new AutographViewModel(autograph)).ToList();

        public int AutographsCount => _memorabilia.Autographs.Count();

        public string AutographDisplayCount => $"{AutographsCount} Autograph(s)";

        public int? BrandId => _memorabilia.Brand?.BrandId;

        public int? ConditionId => _memorabilia.ConditionId;

        public string ConditionName => _memorabilia.Condition?.Name;

        public DateTime CreateDate => _memorabilia.CreateDate;

        public bool DisplayAutographDetails { get; set; }

        public int? Denominator => _memorabilia.Denominator;

        public decimal? EstimatedValue => _memorabilia.EstimatedValue;

        public string FormattedCreateDate => CreateDate.ToString("MM-dd-yyyy");

        public string FormattedLastModifiedDate => LastModifiedDate?.ToString("MM-dd-yyyy");

        public string FormattedTotalCost => ((Acquisition?.Cost ?? 0) + _memorabilia.Autographs.Sum(autograph => autograph.Acquisition?.Cost ?? 0)).ToString("c");

        public string FormattedTotalValue => ((EstimatedValue ?? 0) + _memorabilia.Autographs.Sum(autograph => autograph.EstimatedValue ?? 0)).ToString("c");

        public IEnumerable<Franchise> Franchises => Teams.Select(team => team.Team.Franchise);

        public int? GameStyleTypeId => _memorabilia.Game?.GameStyleTypeId;

        public bool HasAutographs => _memorabilia.Autographs.Any();

        public int Id => _memorabilia.Id;

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

        public string ImagePath => !_memorabilia.Images.Any() 
            ? "wwwroot/images/imagenotavailable.png"
            : _memorabilia.Images.FirstOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id)?.FilePath ?? _memorabilia.Images.First().FilePath;

        public List<MemorabiliaImage> Images => _memorabilia.Images;

        public int ItemTypeId => _memorabilia.ItemTypeId;

        public string ItemTypeName => _memorabilia.ItemType?.Name;

        public DateTime? LastModifiedDate => _memorabilia.LastModifiedDate;

        public int? LevelTypeId => _memorabilia?.LevelType?.Id;

        public string MemorabiliaImagePath => $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(ImagePath))}";

        public string Note => _memorabilia.Note;

        public int? Numerator => _memorabilia.Numerator;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public int? PrimaryAutographId => _memorabilia.Autographs.FirstOrDefault()?.Id;

        public string PrimaryAutographImagePath => HasAutographs 
            ? _memorabilia.Autographs
                          .SelectMany(autograph => autograph.Images)
                          .SingleOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id)?.FilePath ?? "images/imagenotavailable.png"
            : "images/imagenotavailable.png";

        public int PrivacyTypeId => _memorabilia.PrivacyTypeId;

        public string PrivacyTypeName => Domain.Constants.PrivacyType.Find(_memorabilia.PrivacyTypeId).Name;        

        public int? PurchaseTypeId => _memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId;

        public string PurchaseTypeName => Domain.Constants.PurchaseType.Find(_memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId ?? 0)?.Name;

        public int? SizeId => _memorabilia.Size?.SizeId;        

        public IEnumerable<SportLeagueLevel> SportLeagueLevels => Franchises.Select(franchise => franchise.SportLeagueLevel);

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;

        public string ToggleIcon { get; set; } = MudBlazor.Icons.Material.Filled.ExpandMore;

        public string UserFirstName => _memorabilia.User.FirstName;

        public int UserId => _memorabilia.UserId;
    }
}
