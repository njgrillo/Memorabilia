namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteMemorabiliaGalleryItemModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public SiteMemorabiliaGalleryItemModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;

        Autographs = _memorabilia.Autographs
                                 .Select(autograph => new SiteAutographGalleryModel(autograph)); 
    }

    public IEnumerable<SiteAutographGalleryModel> Autographs { get; set; } 
        = Enumerable.Empty<SiteAutographGalleryModel>();

    public string Description
        => "TODO"; 

    public int Id => _memorabilia.Id;

    public string ImageFileName
    {
        get
        {
            string imageFileName = _memorabilia.Images.Count != 0
                ? _memorabilia.Images
                              .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName ?? Constant.ImageFileName.ImageNotAvailable
                : Constant.ImageFileName.ImageNotAvailable;

            return !imageFileName.IsNullOrEmpty()
                ? imageFileName
                : Constant.ImageFileName.ImageNotAvailable;
        }
    }

    public Entity.Memorabilia Memorabilia
        => _memorabilia;

    public string Subtitle
        => string.Empty;

    public string Title
    {
        get
        {
            var sb = new StringBuilder();

            sb.Append($"{(_memorabilia.Autographs.Count != 0 ? "Autographed" : "Unsigned")}");

            if (_memorabilia.ItemType.CanHaveTeam() && _memorabilia.Teams.Count != 0)
                sb.Append($" {string.Join(", ", _memorabilia.Teams.Select(team => team.Team.Name))}");

            if (_memorabilia.ItemType.CanHaveSize() && _memorabilia.ItemType.DisplaySizeInTitles)
                sb.Append($" {Constant.Size.Find(_memorabilia.Size.SizeId)?.Name}");

            sb.Append($" {_memorabilia.ItemType.Name}");

            return sb.ToString();
        }
    }

    public string TooltipText
        => Title;
}
