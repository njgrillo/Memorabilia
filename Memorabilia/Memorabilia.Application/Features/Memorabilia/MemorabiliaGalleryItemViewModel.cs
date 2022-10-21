using Memorabilia.Domain.Constants;
using System.Text;

namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemViewModel
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public MemorabiliaGalleryItemViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
        Autographs = _memorabilia.Autographs.Select(autograph => new AutographGalleryViewModel(autograph));
    }

    public IEnumerable<AutographGalleryViewModel> Autographs { get; set; } = Enumerable.Empty<AutographGalleryViewModel>();

    public string Description => $"Estimated Value: {_memorabilia.EstimatedValue + _memorabilia.Autographs.Sum(autograph => autograph.EstimatedValue)}";

    public string EditNavigationPath => $"/Memorabilia/{EditModeType.Update.Name}/{_memorabilia.Id}";

    public int Id => _memorabilia.Id;

    public Domain.Entities.Memorabilia Memorabilia => _memorabilia;

    public string PrimaryImageNavigationPath => $"/Memorabilia/Image/{EditModeType.Update.Name}/{Id}";

    public string PrimaryImagePath
    {
        get
        {
            var primaryImagePath = _memorabilia.Images.Any()
                ? _memorabilia.Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FilePath ?? ImagePath.ImageNotAvailable
                : ImagePath.ImageNotAvailable;

            if (primaryImagePath.IsNullOrEmpty() || !File.Exists(primaryImagePath))
                primaryImagePath = ImagePath.ImageNotAvailable;

            return $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(primaryImagePath))}";
        }
    }

    public string Subtitle => string.Empty;

    public string Title
    {
        get
        {
            var sb = new StringBuilder();

            sb.Append($"{(_memorabilia.Autographs.Any() ? "Autographed" : "Unsigned")}");

            if (ItemType.CanHaveTeam(_memorabilia.ItemType) && _memorabilia.Teams.Any())
                sb.Append($" {string.Join(", ", _memorabilia.Teams.Select(team => team.Team.Name))}");

            if (ItemType.CanHaveSize(_memorabilia.ItemType) && _memorabilia.ItemType.DisplaySizeInTitles)
                sb.Append($" {Size.Find(_memorabilia.Size.SizeId)?.Name}");

            sb.Append($" {_memorabilia.ItemType.Name}");

            return sb.ToString();
        }
    }

    public string TooltipText => Title;
}
