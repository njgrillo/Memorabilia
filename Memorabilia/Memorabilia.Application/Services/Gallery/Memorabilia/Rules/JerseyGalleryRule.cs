namespace Memorabilia.Application.Services.Gallery.Memorabilia.Rules;

public class JerseyGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Constant.ItemType itemType)
        => itemType == Constant.ItemType.Jersey;

    public override string AutographTitleText(Entity.Memorabilia memorabilia)
        => memorabilia.Autographs.Count switch
        {
            0 => string.Empty,
            1 => "Autographed",
            > 1 => "Multi Signed",
            _ => string.Empty,
        };

    public override string GetTitle(Entity.Memorabilia memorabilia)
        => $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {ItemTypeText(memorabilia)}";
}
