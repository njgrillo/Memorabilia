namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public MemorabiliaGalleryItemModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;

        Autographs = _memorabilia.Autographs
                                 .Select(autograph => new AutographGalleryModel(autograph));
    }

    public IEnumerable<AutographGalleryModel> Autographs { get; set; } 
        = Enumerable.Empty<AutographGalleryModel>();

    public string Description 
        => $"Estimated Value: {_memorabilia.EstimatedValue + _memorabilia.Autographs.Sum(autograph => autograph.EstimatedValue)}";

    public string EditNavigationPath 
        => $"/Memorabilia/{Constant.EditModeType.Update.Name}/{_memorabilia.Id}";

    public int Id => _memorabilia.Id;

    public string ImageFileName
    {
        get
        {
            string imageFileName = _memorabilia.Images.Any()
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

    public string PrimaryImageNavigationPath 
        => $"/Memorabilia/Image/{Constant.EditModeType.Update.Name}/{Id}";    

    public string Subtitle 
        => string.Empty;

    public string Title
    {
        get
        {
            var sb = new StringBuilder();

            sb.Append($"{(_memorabilia.Autographs.Any() ? "Autographed" : "Unsigned")}");

            if (_memorabilia.ItemType.CanHaveTeam() && _memorabilia.Teams.Any())
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
