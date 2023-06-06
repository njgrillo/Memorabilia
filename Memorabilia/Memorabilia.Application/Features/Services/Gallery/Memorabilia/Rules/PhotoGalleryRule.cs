namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class PhotoGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Constant.ItemType itemType)
    {
        return itemType == Constant.ItemType.Photo;
    }

    public override string AutographTitleText(Entity.Memorabilia memorabilia)
    {
        return memorabilia.Autographs.Count switch
        {
            0 => string.Empty,
            1 => "Autographed",
            > 1 => "Multi Signed",
            _ => string.Empty,
        };
    }

    public override string GetTitle(Entity.Memorabilia memorabilia)
    {
        return $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {SizeText(memorabilia)} {ItemTypeText(memorabilia)}";
    }
}
